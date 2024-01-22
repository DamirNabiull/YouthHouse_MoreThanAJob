using System.IO;
using System.Linq;
using Interfaces;
using UnityEngine;

public class FormController : MonoBehaviour, IClearable, ISave
{
    public TextFieldController[] textFieldControllers;
    public ToggleController[] toggles;

    private static readonly string FilePath = Application.streamingAssetsPath + "/data.csv";

    public bool Save()
    {
        var isCorrect = textFieldControllers
            .Aggregate(true, (current, field) => current && field.Check());

        isCorrect = toggles.Aggregate(isCorrect, (current, toggle) => current && toggle.Check());

        if (!isCorrect) return false;
        
        Debug.Log("Correct");
        SaveToFile();
        return true;

    }
    
    public void Clear()
    {
        ClearTextFields();
        ClearToggles();
    }

    private void ClearTextFields()
    {
        if (textFieldControllers == null) return;

        foreach (var obj in textFieldControllers)
        {
            obj.Clear();
        }
    }
    
    private void ClearToggles()
    {
        if (toggles == null) return;
        
        foreach (var obj in toggles)
        {
            var clearable = obj.gameObject.GetComponent<IClearable>();
            clearable?.Clear();
        }
    }
    
    private void SaveToFile()
    {
        var phone = GetTextByObjectName("PhoneField");
        var type = GetTextByObjectName("TypeField");
        var university = GetTextByObjectName("UniversityField");
        
        File.AppendAllText(FilePath, $"{phone}|{university}|{type}\n");
    }

    private string GetTextByObjectName(string objectName)
    {
        var obj = textFieldControllers.FirstOrDefault(x => x.GetName() == objectName);
        return obj != default 
            ? obj.GetText() 
            : "";
    }
}
