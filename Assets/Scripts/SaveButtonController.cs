using Interfaces;
using UnityEngine;

public class SaveButtonController : ButtonController
{
    public GameObject toSave;

    public override void NormalClick()
    {
        if (Save())
        {
            NormalAction();
        }
    }

    private bool Save()
    {
        if (toSave == null) return true;
        
        var save = toSave.GetComponent<ISave>();
        var result = save?.Save();
        return result.HasValue && result.Value;
    }
}