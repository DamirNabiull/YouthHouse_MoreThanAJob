using UnityEngine.UI;

public class ButtonController : ShowHideController
{
    public bool isTransparentBack = false;
    
    private void Start()
    {
        if (!isTransparentBack) return;
        
        var image = GetComponent<Image>();

        if (image != null)
        {
            image.alphaHitTestMinimumThreshold = 1f;
        }
    }

    public virtual void NormalClick()
    {
        NormalAction();
    }
    
    public void InverseClick()
    {
        InverseAction();
    }
}