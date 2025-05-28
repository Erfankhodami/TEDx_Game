using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmpro;
    [SerializeField] private GameObject LoosePanel;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private float panelOpeningSpeed=1;
    private Vector3 panelLowSize = new Vector3(1, 1, 1);
    private Vector3 panelHighSize = new Vector3(10,10,1);
    
    private PlayerMovementController _playerMovementController;
    private void Start()
    {
        _playerMovementController = GameObject.Find("Player").GetComponent<PlayerMovementController>();
        startPanel.transform.localScale = panelLowSize;
        LoosePanel.transform.localScale = panelHighSize;
        PlayerMovementController.OnGameOver += Loose;
    }

    public void UpdateScore(int score)
    {
        tmpro.text = "Score: " + score;
    }

    public void Loose()
    {
        StartCoroutine(BringUpLoosePanel());
    }

    private IEnumerator BringUpLoosePanel()
    {
        while (LoosePanel.transform.localScale.x>1)
        {
            LoosePanel.transform.localScale = Vector3.Slerp(LoosePanel.transform.localScale, panelLowSize,
                panelOpeningSpeed / 10);
            yield return null;
        }
    }

    public void StartGame()
    {
        StartCoroutine(BringDownStartPanel());
        //print("bringing down");
    }

    IEnumerator BringDownStartPanel()
    {
        while (startPanel.transform.localScale.x<panelHighSize.x-.1f)
        {
            //print("bringing down");
            startPanel.transform.localScale=Vector3.Slerp(startPanel.transform.localScale,panelHighSize,panelOpeningSpeed/10);
            yield return null;
        }
        startPanel.SetActive(false);
        yield return null;
    }
    public void RestartGame()
    {
        _playerMovementController.DisableSubscriptions();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
