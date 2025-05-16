using System;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float forcePower = 10;
    [SerializeField] private float maxSpeed = 10, minSpeed = -10;
    [SerializeField] private float overlapCircleRadious = .5f;
    private LayerMask obsticleMask;
    private Rigidbody2D playerRb;
    private void Start()
    {
        obsticleMask = LayerMask.GetMask("Obstacle");
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float clampedVelocity = Mathf.Clamp(playerRb.linearVelocityY, minSpeed, maxSpeed);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.linearVelocityY = forcePower;
        }

        float ySpeed = playerRb.linearVelocityY;
        float lerpedValue = Mathf.Lerp(.5f, Map(ySpeed), .2f);
        transform.rotation = Quaternion.Slerp(Quaternion.Euler(0,0,-40), Quaternion.Euler(0,0,120), lerpedValue);

        Collider2D hit=Physics2D.OverlapCircle(transform.position, overlapCircleRadious, obsticleMask);
        if (hit != null)
        {
            print("lost");
            Time.timeScale = 0;
        }
    }

    float Map(float value)
    {
        float mapped = (value - minSpeed) / (maxSpeed - minSpeed);
        return mapped;
    }
}
