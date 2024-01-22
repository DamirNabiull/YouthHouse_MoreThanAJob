using UnityEngine;

public class ResetTimer : ShowHideController
{
    private const float RestartTime = 120f;
    private float _lastUpdateTime = 0;
    private bool _countTime = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Reset();
        }

        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Reset();
            }
        }

        if (Time.time - _lastUpdateTime > RestartTime && _countTime)
        {
            _countTime = false;
            Notify();
        }
    }

    private void Reset()
    {
        _countTime = true;
        _lastUpdateTime = Time.time;
    }

    private void Notify()
    {
        NormalAction();
    }
}
