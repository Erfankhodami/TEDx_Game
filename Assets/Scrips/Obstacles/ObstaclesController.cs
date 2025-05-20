using System;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    private float movingSpeed=15;

    private void Start()
    {
        Invoke("DestroyGm",10);
    }

    void Update()
    {
        transform.Translate(Vector3.left*movingSpeed*Time.deltaTime);
    }

    void DestroyGm()
    {
        Destroy(gameObject);
    }
}
