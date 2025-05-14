using System;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    [SerializeField] private float forcePower = 10;
    [SerializeField] private float maxSpeed = 10, minSpeed = -10;

    private void Start()
    {
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
    }

    float Map(float value)
    {
        float mapped = (value - minSpeed) / (maxSpeed - minSpeed);
        return mapped;
    }
}
