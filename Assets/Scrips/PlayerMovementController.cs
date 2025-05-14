using System;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    [SerializeField] private float forcePower = 10;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerRb.gravityScale = 0;
    }

    void Update()
    {
        Vector2 foreceDir = new Vector2(0, 1);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(foreceDir*forcePower,ForceMode2D.Impulse);
        }
    }
}
