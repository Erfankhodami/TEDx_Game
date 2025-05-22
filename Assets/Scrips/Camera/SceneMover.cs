using UnityEngine;

public class SceneMover : MonoBehaviour
{
    [SerializeField] private float movingSpeed=15;
    void Update()
    {
        transform.Translate(Vector3.right*movingSpeed*Time.deltaTime);
        if (transform.position.x > 10000)
        {
            transform.position = new Vector3(-10000, 0, 0);
        }
    }
}
