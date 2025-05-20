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
    void Start()
    {
        InvokeRepeating("GenerateObstacles",1,2);
    }
    void GenerateObstacles()
    {
        Vector3 offset = new Vector3(0,
            Random.Range(obstacleRandomRange.lowerValue, obstacleRandomRange.upperValue),0);
        Instantiate(obstaclePrefab, transform.position + offset, quaternion.identity);
        
        Vector3 dist=new Vector3(0,
            Random.Range(spaceSizeRange.lowerValue, spaceSizeRange.upperValue),0);
        offset += dist;
        
        GameObject obstacle=Instantiate(obstaclePrefab, transform.position + offset, quaternion.identity);
        
        GameObject glass=Instantiate(glassPrefab,obstacle.transform.position-dist/2,Quaternion.identity);


        scale = dist.y - obstacle.transform.localScale.y;
        var transformLocalScale = glass.transform.localScale;
        transformLocalScale.y = scale;
        glass.transform.localScale = transformLocalScale;
    }

    public float GetScale()
    {
        return scale;
    }
}
