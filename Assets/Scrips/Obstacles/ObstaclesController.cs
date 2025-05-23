using System;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    public static float movingSpeed=11;

    private void Start()
    {
        Invoke("DestroyGm",10);
        PlayerMovementController.OnGameOver += StopMoving;
    }

    void Update()
    {
        transform.Translate(Vector3.left*movingSpeed*Time.deltaTime);
    }

    void DestroyGm()
    {
        Destroy(gameObject);
    }

    public void StopMoving()
    {
        movingSpeed=0;
    }
}
