using System;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float forcePower = 10;
    [SerializeField] private float maxSpeed = 10, minSpeed = -10;
    [SerializeField] private float overlapCircleRadious = .5f;
    [SerializeField] private Range rotatioinRange;
    private LayerMask obsticleMask;
    private Rigidbody2D playerRb;
    private EffectsAndScoerController _effectsAndScoerController;
    private PlayerAnimationController _playerAnimationController;
    private void Start()
    {
        _playerAnimationController = GetComponent<PlayerAnimationController>();
        _effectsAndScoerController = GetComponent<EffectsAndScoerController>();
        obsticleMask = LayerMask.GetMask("Obstacle");
        playerRb = GetComponent<Rigidbody2D>();
        playerRb.linearVelocityY = forcePower;
    }

    void Update()
    {
        float clampedVelocity = Mathf.Clamp(playerRb.linearVelocityY, minSpeed, maxSpeed);
        if (Input.GetKeyDown(KeyCode.Space))
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
            if (hit.gameObject.tag == "Wall")
            {
                print("lost");
                //Time.timeScale = 0;    
            }else if (hit.gameObject.tag == "Glass")
            {
             print("glass");   
             _effectsAndScoerController.CallEffect(hit.gameObject);
            }
        }
    }

    float Map(float value)
    {
        float mapped = (value - minSpeed) / (maxSpeed - minSpeed);
        return mapped;
    }
}
