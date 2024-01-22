using Interfaces;
using UnityEngine;

public class ShowHideController : MonoBehaviour
{
    public GameObject[] toShow;
    public GameObject[] toHide;
    public GameObject[] toClear;

    protected void NormalAction()
    {
        if (toShow != null)
        {
            foreach (var obj in toShow)
            {
                obj.SetActive(true);
            }
        }

        if (toHide != null)
        {
            foreach (var obj in toHide)
            {
                obj.SetActive(false);
            }
        }
        
        ClearAction();
    }

    protected void InverseAction()
    {
        if (toShow != null)
        {
            foreach (var obj in toShow)
            {
                obj.SetActive(false);
            }
        }

        if (toHide != null)
        {
            foreach (var obj in toHide)
            {
                obj.SetActive(true);
            }
        }
    }

    private void ClearAction()
    {
        if (toClear == null) return;

        foreach (var obj in toClear)
        {
            var clearable = obj.GetComponent<IClearable>();
            clearable?.Clear();
        }
    }
}