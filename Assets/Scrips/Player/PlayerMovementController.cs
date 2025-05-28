using System;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public int score = 0;
    [SerializeField] private float forcePower = 10;
    [SerializeField] private float maxSpeed = 10, minSpeed = -10;
    [SerializeField] private float overlapCircleRadious = .5f;
    [SerializeField] private Range rotatioinRange;
    private bool isGameOver=false;
    private LayerMask obsticleMask;
    private Rigidbody2D playerRb;
    private EffectsAndScoerController _effectsAndScoerController;
    private PlayerAnimationController _playerAnimationController;
    private SceneMover _sceneMover;

    public static event Action OnGameOver;
    private void Start()
    {
        Time.timeScale = 0;
        _sceneMover = Camera.main.gameObject.GetComponent<SceneMover>();
        _playerAnimationController = GetComponent<PlayerAnimationController>();
        _effectsAndScoerController = GetComponent<EffectsAndScoerController>();
        obsticleMask = LayerMask.GetMask("Obstacle");
        playerRb = GetComponent<Rigidbody2D>();
        playerRb.linearVelocityY = forcePower;
        playerRb.simulated = false;
    }

    void Update()
    {
        playerRb.linearVelocityY=Mathf.Clamp(playerRb.linearVelocityY, minSpeed, maxSpeed);
        if (Input.GetMouseButtonDown(0)&&!isGameOver)
        {
            playerRb.linearVelocityY = forcePower;
            _playerAnimationController.RunIenumerator();
        }

        float ySpeed = playerRb.linearVelocityY;
        float lerpedValue = Mathf.Lerp(.5f, Map(ySpeed), .2f);
        transform.rotation = Quaternion.Slerp(Quaternion.Euler(0,0,rotatioinRange.lowerValue), Quaternion.Euler(0,0,rotatioinRange.upperValue), lerpedValue);

        Collider2D hit=Physics2D.OverlapCircle(transform.position, overlapCircleRadious, obsticleMask);
        if (hit != null)
        {
            if (hit.gameObject.tag == "Wall"&&!isGameOver)
            {
                print("lost");
                LooseGame();
            }else if (hit.gameObject.tag == "Glass")
            {
             print("glass");   
             _effectsAndScoerController.CallEffect(hit.gameObject);
            }
        }

        if (transform.position.y < -100)
        {
            LooseGame();
        }
    }

    float Map(float value)
    {
        float mapped = (value - minSpeed) / (maxSpeed - minSpeed);
        return mapped;
    }

    void LooseGame()
    {
        float throwBackForce = 5;
        isGameOver = true;
        OnGameOver.Invoke();
        playerRb.AddForce((Vector2.left + Vector2.up)*throwBackForce,ForceMode2D.Impulse);
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        playerRb.simulated = true;
    }
    public void DisableSubscriptions()
    {
        OnGameOver = null;
    }
}
