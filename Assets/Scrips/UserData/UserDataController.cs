using UnityEngine;


public class userData
{
    public string number;
    public int highestScore;

    public userData(string _number, int _highestScore)
    {
        number = _number;
        highestScore = _highestScore;
    }
}
public class UserDataController : MonoBehaviour
{
    private bool numberAdded;
    private userData _userData=new userData("",0);
    private UIController _uiController;
    void Start()
    {
        _uiController = Camera.main.gameObject.GetComponent<UIController>();
        CheckForNumber();
        GetHighestScoreFromPlayerPrefs();
        _uiController.UpdateHighestScoreText(_userData.highestScore);
        print(PlayerPrefs.GetInt("best"));
    }

    void CheckForNumber()
    {
        string result = PlayerPrefs.GetString("number");
        if (result.Length != 11)
        {
            _uiController.BringUpNumberInputPanel();
        }
        else
        {
            _uiController.BringDownNumberInputPanelAndBringUpStartPanel();
            _userData.number = result;
        }
        //print(number);
    }

    void GetHighestScoreFromPlayerPrefs()
    {
        _userData.highestScore = PlayerPrefs.GetInt("best");
        print(_userData.highestScore);
    }

    public void SetNumber(string _number)
    {
        _userData.number = _number;
    }

    public int GetHighestScore()
    {
        return _userData.highestScore;
    }

    public void SetHighestScore(int score)
    {
        _userData.highestScore = score;
        PlayerPrefs.SetInt("best",score);
        print("highes score set");
    }

    public userData GetUserData()
    {
        return _userData;
    }
}
