using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class EffectsAndScoerController : MonoBehaviour
{
    [SerializeField] private GameObject EffectPrefab;
    private ObstaclesGenerator _obstaclesGenerator;
    private float coolDown = 1;
    private bool canInstantiate = true;

    private void Start()
    {
        _obstaclesGenerator = GameObject.Find("ObstaclesGenerator").GetComponent<ObstaclesGenerator>();
    }

    public void CallEffect(GameObject hit)
    {
        if (!canInstantiate)
        {
            return;
        }

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