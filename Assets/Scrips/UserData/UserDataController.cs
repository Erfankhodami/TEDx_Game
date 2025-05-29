using UnityEngine;

public class UserDataController : MonoBehaviour
{
    private bool numberAdded;
    private string number="";
    private UIController _uiController;
    void Start()
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
        print(number);
    }

    public void SetNumber(string _number)
    {
        number = _number;
    }
}
