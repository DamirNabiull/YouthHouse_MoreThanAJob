using System.Text.RegularExpressions;
using Enums;
using Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextFieldController : MonoBehaviour, ISelectHandler, IDeselectHandler, IClearable, ICheckable
{
    public bool hidePlaceHolder;
    public int minLenght = 0;
    public int maxLength = 0;
    public string prefix;
    public string regexValidation;
    public KeyboardType keyboardType;

    private TMP_InputField _textField;
    private KeyboardController _keyboardController;
    private Animator _animator;
    private Regex _regex;
    private bool _isAnimated;

    private void Start()
    {
        _textField = GetComponent<TMP_InputField>();
        _animator = GetComponent<Animator>();
        _keyboardController = FindObjectOfType<KeyboardController>();
        _regex = new Regex(regexValidation, RegexOptions.Compiled);
    }

    public void OnSelect(BaseEventData eventData)
    {
        _keyboardController.ShowKeyboard();
        _keyboardController.SetInputField(ref _textField, prefix);
        _keyboardController.SetLayout(keyboardType);
        
        if (hidePlaceHolder)
        {
            _textField.placeholder.gameObject.SetActive(false);
        }
    }
    
    public void OnDeselect(BaseEventData eventData)
    {
        if (hidePlaceHolder)
        {
            _textField.placeholder.gameObject.SetActive(true);
        }
    }

    public bool Check()
    {
        if (_textField.text.Length >= minLenght)
        {
            return maxLength <= 0 || _textField.text.Length <= maxLength;
        }
        
        _animator.Play("TextFieldWarning",  -1, 0f);
        
        return false;
    }

    public void BackSpace()
    {
        if (_textField.text.Length > prefix.Length)
        {
            _textField.text = _textField.text.Remove(_textField.text.Length - 1, 1);
        }
    }

    public void AlphabetFunction(string alphabet)
    {
        if (_regex.IsMatch(alphabet) && (maxLength <= 0 || _textField.text.Length < maxLength))
        {
            _textField.text = _textField.text.Insert(_textField.text.Length, alphabet);
        }
    }

    public string GetName()
    {
        return gameObject.name;
    }

    public string GetText()
    {
        return _textField == null ? "" : _textField.text;
    }

    public void Clear()
    {
        if (_textField == null) return;

        _textField.text = "";
        _textField.placeholder.gameObject.SetActive(true);
    }
}