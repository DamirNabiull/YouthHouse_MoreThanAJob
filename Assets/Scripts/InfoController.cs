using Interfaces;
using UnityEngine;

public class InfoController : MonoBehaviour, IClearable
{
    public GameObject info;
    
    public void Clear()
    {
        for (var i = 0; i < info.transform.childCount; i++)
        {
            var child = info.transform.GetChild(i).gameObject;
            if (child != null)
            {
                child.SetActive(false);
            }
        }
        
        gameObject.SetActive(false);
    }
}