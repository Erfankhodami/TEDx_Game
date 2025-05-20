using System;
using System.Collections;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void RunIenumerator()
    {
        StartCoroutine(RunAnimation());
    }
    private IEnumerator RunAnimation()
    {
        float delaySeconds = .1f;
        
        for (int i = 0; i < sprites.Length; i++)
        {
            _spriteRenderer.sprite = sprites[i];
            yield return new WaitForSeconds(delaySeconds);
        }
    }
}
