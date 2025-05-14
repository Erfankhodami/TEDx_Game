using System;
using UnityEngine;

public class TImeController : MonoBehaviour
{
    [SerializeField]private float startSpeed=1;

    private void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        Time.timeScale = Mathf.Lerp(0.5f, 1, startSpeed/10);
    }
}
