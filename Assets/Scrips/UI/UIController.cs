using System;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmpro;
    [SerializeField] private GameObject LoosePanel;
    private void Start()
    {
        PlayerMovementController.OnGameOver += Loose;
    }

    public void UpdateScore(int score)
    {
        tmpro.text = "Score: " + score;
    }

    public void Loose()
    {
        
    }
}
