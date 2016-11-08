using UnityEngine;
using System.Collections;

public class TouchOnRightButton : ColliderTouchBehaviour
{
    public override void OnStart(PointEventArgs e)
    {
        WorldComponent.Sandbox.RightPressed.Publish(true);
    }

    public override void OnStay(PointEventArgs e)
    {
        WorldComponent.Sandbox.RightPressed.Publish(true);
    }

    public override void OnCancel(PointEventArgs e)
    {
        WorldComponent.Sandbox.RightPressed.Publish(false);
    }

    public override void OnEnd(PointEventArgs e)
    {
        WorldComponent.Sandbox.RightPressed.Publish(false);
    }
}
