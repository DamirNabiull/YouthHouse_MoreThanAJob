using System;
using Enums;
using TMPro;
using UnityEngine;

public class KeyboardController : ShowHideController
{
    public GameObject form;
    public GameObject keyboard;
    public KeyboardScript keyboardScript;

    private void Start()
    {
        keyboard = GameObject.FindWithTag("Keyboard");
        HideKeyboard();
        form.SetActive(false);
    }

    public void ShowKeyboard()
    {
        keyboard.SetActive(true);
        NormalAction();
    }
    
    public void HideKeyboard()
    {
        CloseAllLayouts();
        keyboard.SetActive(false);
        InverseAction();
    }

    public void SetInputField(ref TMP_InputField field, string prefix)
    {
        if (field.text.Length == 0)
        {
            field.text = prefix;
        }
        field.caretPosition = field.text.Length;
        keyboardScript.SetTextField(ref field);
    }

    public void SetLayout(KeyboardType type)
    {
        switch (type)
        {
            case KeyboardType.RusLayoutBig:
                keyboardScript.ShowLayout(keyboardScript.RusLayoutBig);
                break;
            case KeyboardType.EngLayoutBig:
                keyboardScript.ShowLayout(keyboardScript.EngLayoutBig);
                break;
            case KeyboardType.RusLayoutSml:
                keyboardScript.ShowLayout(keyboardScript.RusLayoutSml);
                break;
            case KeyboardType.EngLayoutSml:
                keyboardScript.ShowLayout(keyboardScript.EngLayoutSml);
                break;
            case KeyboardType.SymbLayout:
                keyboardScript.ShowLayout(keyboardScript.SymbLayout);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }

    public void CloseAllLayouts()
    {
        keyboardScript.CloseAllLayouts();
    }
}
