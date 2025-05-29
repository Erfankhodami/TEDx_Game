using UnityEngine;

public class UserDataController : MonoBehaviour
{
    private bool numberAdded;
    private string number=""; 
    private int highstScore = 0;
    private UIController _uiController;
    void Start()
    {
        CheckForNumber();
        GetHighestScoreFromPlayerPrefs();
        _uiController.UpdateHighestScoreText(highstScore);
        print(PlayerPrefs.GetInt("best"));
    }

    void CheckForNumber()
    {
        _uiController = Camera.main.gameObject.GetComponent<UIController>();
        string result = PlayerPrefs.GetString("number");
        if (result.Length != 11)
        {
            _uiController.BringUpNumberInputPanel();
        }
        else
        {
            _uiController.BringDownNumberInputPanelAndBringUpStartPanel();
            number = result;
        }
        //print(number);
    }

    void GetHighestScoreFromPlayerPrefs()
    {
        highstScore = PlayerPrefs.GetInt("best");
        print(highstScore);
    }

    public void SetNumber(string _number)
    {
        number = _number;
    }

    public int GetHighestScore()
    {
        return highstScore;
    }

    public void SetHighestScore(int score)
    {
        highstScore = score;
        PlayerPrefs.SetInt("best",score);
        print("highes score set");
    }
}
