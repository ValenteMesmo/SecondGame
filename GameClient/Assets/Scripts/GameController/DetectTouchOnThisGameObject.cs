using System;
using UnityEngine;
using UnitySolution.InputComponents;

public class DetectTouchOnThisGameObject : MonoBehaviour
{
    public DetectsTouchOnAnyCollidersInScene TouchDetector;

    void Start()
    {
        var touches = TouchDetector;
        touches.OnStart += inputs_OnTouch;
        touches.OnEnd += inputs_OffTouch;
        touches.OnStay += inputs_OnTouchStay;
        touches.OnCancel += touches_OnCancel;
    }

    public event EventHandler<PointEventArgs> OnCancel;
    void touches_OnCancel(object sender, PointEventArgs e)
    {
        if (OnCancel != null && e.Transform.gameObject == gameObject)
            OnCancel(this, e);
    }

    public event EventHandler<PointEventArgs> OnEnd;
    private void inputs_OffTouch(object sender, PointEventArgs e)
    {
        if (OnEnd != null && e.Transform.gameObject == gameObject)
            OnEnd(this, e);
    }

    public event EventHandler<PointEventArgs> OnStart;
    private void inputs_OnTouch(object sender, PointEventArgs e)
    {
        if (OnStart != null && e.Transform.gameObject == gameObject)
            OnStart(this, e);
    }

    public event EventHandler<PointEventArgs> OnStay;
    private void inputs_OnTouchStay(object sender, PointEventArgs e)
    {
        if (OnStay != null && e.Transform.gameObject == gameObject)
            OnStay(this, e);
    }
}
