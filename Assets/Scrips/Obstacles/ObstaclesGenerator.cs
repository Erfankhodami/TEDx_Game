using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstaclesGenerator : MonoBehaviour
{
    [System.Serializable]
    class Range
    {
        public float upperValue;
        public float lowerValue;
    }
    
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private Range obstacleRandomRange;
    [SerializeField] private Range spaceSizeRange;

    private Transform origin;
    void Start()
    {
        InvokeRepeating("GenerateObstacles",1,2);
    }
    void Update()
    {
        
    }

    void GenerateObstacles()
    {
        origin = transform;
        Vector3 offset = new Vector3(0,
            Random.Range(obstacleRandomRange.lowerValue, obstacleRandomRange.upperValue),0);
        Instantiate(obstaclePrefab, origin.position + offset, quaternion.identity);
        offset+=new Vector3(0,
            Random.Range(spaceSizeRange.lowerValue, spaceSizeRange.upperValue),0);
        Instantiate(obstaclePrefab, origin.position + offset, quaternion.identity);

    }
}
