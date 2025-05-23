using System;
using UnityEngine;

public class SceneMover : MonoBehaviour
{
    [SerializeField] private float movingSpeed=10;

    private void Start()
    {
        PlayerMovementController.OnGameOver += StopMoving;
    }

    void Update()
    {
        transform.Translate(Vector3.right*movingSpeed*Time.deltaTime);
        if (transform.position.x > 10000)
        {
            transform.position = new Vector3(-10000, 0, 0);
        }
    }

    public void StopMoving()
    {
        movingSpeed = 0;
    }
}
