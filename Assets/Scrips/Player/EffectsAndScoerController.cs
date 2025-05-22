using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

public class EffectsAndScoerController : MonoBehaviour
{
    [SerializeField] private GameObject EffectPrefab;
    [SerializeField] private int Score;
    private ObstaclesGenerator _obstaclesGenerator;
    private UIController _uiController;
    private float coolDown = 1;
    private bool canInstantiate = true;
    
    private void Start()
    {
        _uiController = Camera.main.gameObject.GetComponent<UIController>();
        _obstaclesGenerator = GameObject.Find("ObstaclesGenerator").GetComponent<ObstaclesGenerator>();
    }

    public void CallEffect(GameObject hit)
    {
        if (!canInstantiate)
        {
            return;
        }

        Score++;
        _uiController.UpdateScore(Score);
        Vector3 offset = new Vector3(0, 0, 0);
        var effect = Instantiate(EffectPrefab,hit.transform.position+offset, quaternion.identity).GetComponent<ParticleSystem>().shape;
        effect.scale = new Vector3(1, _obstaclesGenerator.GetScale(),1) ;
        StartCoroutine(DestroyGlass(hit.GetComponent<SpriteRenderer>()));
        canInstantiate = false;
        Invoke("RunCoolDown",coolDown);
    }

    void RunCoolDown()
    {
        canInstantiate = true;
    }

    IEnumerator DestroyGlass(SpriteRenderer spriteRenderer)
    {
        float stepsCount = 15;
        for (int i = 0; i < stepsCount; i++)
        {
            var spriteRendererColor = spriteRenderer.color;
            spriteRendererColor.a -= 1 / stepsCount;
            spriteRenderer.color = spriteRendererColor;
            yield return null;
        }
        Destroy(spriteRenderer.gameObject);
    }
}