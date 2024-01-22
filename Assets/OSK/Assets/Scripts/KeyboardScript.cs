using TMPro;
using UnityEngine;

public class KeyboardScript : MonoBehaviour
{
    public GameObject cursor;
    public GameObject RusLayoutSml, RusLayoutBig, EngLayoutSml, EngLayoutBig, SymbLayout;

    public int arrowPos;


    private TextFieldController _textFieldController;
    private TMP_InputField _textField;

    public void SetTextField(ref TMP_InputField textField)
    {
        _textField = textField;
        _textFieldController = _textField.gameObject.GetComponent<TextFieldController>();
    }

    public void LeftArrowFunction()
    {   
        if (_textField.caretPosition >= _textField.text.Length)
            _textField.caretPosition = _textField.caretPosition + 1;
    }

    public void RightArrowFunction()
    {
        if (_textField.caretPosition <= 0)
            _textField.caretPosition = _textField.caretPosition - 1;
    }

    public void alphabetFunction(string alphabet)
    {
        if (_textFieldController != null)
        {
            _textFieldController.AlphabetFunction(alphabet);
        }
        else
        {
            _textField.text = _textField.text.Insert(_textField.caretPosition, alphabet);
        }
        

        /*
        
        if (TextField.gameObject.name == "name" && TextField.text.Length == 0)
        {
            CloseAllLayouts();
            ShowLayout(RusLayoutBig);
        }
        else if (TextField.gameObject.name == "surname" && TextField.text.Length == 0)
        {
            CloseAllLayouts();
            ShowLayout(RusLayoutBig);
        }
        else if (TextField.gameObject.name == "father" && TextField.text.Length == 0)
        {
            CloseAllLayouts();
            ShowLayout(RusLayoutBig);
        }
        else if (TextField.gameObject.name == "father" || TextField.gameObject.name == "name" || TextField.gameObject.name == "surname" && TextField.text.Length <= 1)
        {
            CloseAllLayouts();
            ShowLayout(RusLayoutSml);
        }
        
        */

        //TextField.Select();
        //RightArrowFunction();
        _textField.caretPosition = _textField.text.Length;
        //TextField.text.Insert(TextField.caretPosition, alphabet);

        //TextField.ForceLabelUpdate();
        //TextField.MoveTextEnd(true);
        //TextField.ActivateInputField();
    }

    public void BackSpace()
    {
        if (_textFieldController != null)
        {
            _textFieldController.BackSpace();
        }
        else if (_textField.text.Length > 0)
        {
            _textField.text = _textField.text.Remove(_textField.text.Length-1, 1);
        }
    }

    public void CloseAllLayouts()
    {
        RusLayoutSml.SetActive(false);
        RusLayoutBig.SetActive(false);
        EngLayoutSml.SetActive(false);
        EngLayoutBig.SetActive(false);
        SymbLayout.SetActive(false);
    }

    public void ShowLayout(GameObject SetLayout)
    {
        CloseAllLayouts();
        SetLayout.SetActive(true);
    }
}
