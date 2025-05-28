using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
[System.Serializable]
class Range
{
    public float upperValue;
    public float lowerValue;
}
public class ObstaclesGenerator : MonoBehaviour
{
   
    
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private GameObject glassPrefab;
    [SerializeField] private Range obstacleRandomRange;
    [SerializeField] private Range spaceSizeRange;

    private float scale;
    private Transform origin;
    private bool isGameActive = true;
    void Start()
    {
        PlayerMovementController.OnGameOver += DisableInstantiating;
        InvokeRepeating("GenerateObstacles",1,2);
    }
    void GenerateObstacles()
    {
        if (!isGameActive)
        {
            return;
        }
        Vector3 offset = new Vector3(0,
            Random.Range(obstacleRandomRange.lowerValue, obstacleRandomRange.upperValue),0);
        GameObject obstacle=Instantiate(obstaclePrefab, transform.position + offset, quaternion.identity);
        obstacle.transform.parent = transform.parent;
        
        Vector3 dist=new Vector3(0,
            Random.Range(spaceSizeRange.lowerValue, spaceSizeRange.upperValue),0);
        offset += dist;
        
        obstacle=Instantiate(obstaclePrefab, transform.position + offset, quaternion.identity);
        obstacle.transform.parent = transform.parent;
        
        GameObject glass=Instantiate(glassPrefab,obstacle.transform.position-dist/2,Quaternion.identity);
        glass.transform.parent = transform.parent;

        scale = dist.y - obstacle.transform.localScale.y;
        var transformLocalScale = glass.transform.localScale;
        transformLocalScale.y = scale;
        glass.transform.localScale = transformLocalScale;
    }

    public float GetScale()
    {
        return scale;
    }

    void DisableInstantiating()
    {
        isGameActive = false;
    }
}
