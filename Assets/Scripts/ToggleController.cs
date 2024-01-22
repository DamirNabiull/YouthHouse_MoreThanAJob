using Interfaces;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour, IClearable, ICheckable
{
    private Toggle _toggle;
    private Animator _animator;

    private void Start()
    {
        _toggle = GetComponent<Toggle>();
        _animator = GetComponent<Animator>();
    }

    public void Clear()
    {
        if (_toggle != null)
        {
            _toggle.isOn = false;
        }
    }

    public bool Check()
    {
        if (!_toggle.isOn)
        {
            _animator.Play("ToggleWarning",  -1, 0f);
        }

        return _toggle.isOn;
    }
}
