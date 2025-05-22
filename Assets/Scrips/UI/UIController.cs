using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmpro;
    public void UpdateScore(int score)
    {
        tmpro.text = "Score: " + score;
    }
}
