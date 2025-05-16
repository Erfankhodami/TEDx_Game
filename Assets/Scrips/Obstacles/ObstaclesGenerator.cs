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
    [SerializeField] private Range buttonObstacleRandomRange;
    [SerializeField] private Range topObstacleRandomRange;
    
    private Transform origin;
    void Start()
    {
        origin = transform;
        Vector3 offset = new Vector3(0,
            Random.Range(buttonObstacleRandomRange.upperValue, buttonObstacleRandomRange.upperValue),0);
        Instantiate(obstaclePrefab, origin.position + offset, quaternion.identity);
        offset=new Vector3(0,
            Random.Range(topObstacleRandomRange.upperValue, topObstacleRandomRange.upperValue),0);
        Instantiate(obstaclePrefab, origin.position + offset, quaternion.identity);
    }
    void Update()
    {
        
    }
}
