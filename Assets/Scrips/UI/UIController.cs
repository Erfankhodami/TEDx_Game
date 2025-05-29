using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmpro;
    [SerializeField] private GameObject loosePanel;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject inputNumberPanel;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private float panelOpeningSpeed=1;
    private Vector3 panelLowSize = new Vector3(1, 1, 1);
    private Vector3 panelHighSize = new Vector3(10,10,1);
    private UserDataController _userDataController;
    private PlayerMovementController _playerMovementController;
    private void Start()
    {
        _userDataController = Camera.main.gameObject.GetComponent<UserDataController>();
        _playerMovementController = GameObject.Find("Player").GetComponent<PlayerMovementController>();
        startPanel.transform.localScale = panelLowSize;
        loosePanel.transform.localScale = panelHighSize;
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
        loosePanel.SetActive(true);
        while (loosePanel.transform.localScale.x>1)
        {
            loosePanel.transform.localScale = Vector3.Slerp(loosePanel.transform.localScale, panelLowSize,
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
        while (startPanel.transform.localScale.x<panelHighSize.x-.2f)
        {
            //print("bringing down");
            startPanel.transform.localScale=Vector3.Lerp(startPanel.transform.localScale,panelHighSize,panelOpeningSpeed/10);
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

    public void BringUpNumberInputPanel()
    {
        inputNumberPanel.SetActive(true);   
        startPanel.SetActive(false);

    }
    public void GetNumber()
    {
        GetNumberFromInputField();
    }
    public void GetNumberFromInputField()
    {
        string result = _inputField.text;
        if (result.Length != 11)
        {
            return;
        }
        BringDownNumberInputPanelAndBringUpStartPanel();
        PlayerPrefs.SetString("number",result);
        _userDataController.SetNumber(result);
    }
    
    public void BringDownNumberInputPanelAndBringUpStartPanel()
    {
        inputNumberPanel.SetActive(false);
        startPanel.SetActive(true);
    }
}
