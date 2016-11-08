using UnityEngine;
using System.Collections;

public class TouchOnLeftButton : ColliderTouchBehaviour
{
    public override void OnStart(PointEventArgs e)
    {
        WorldComponent.Sandbox.LeftPressed.Publish(true);
    }

    public override void OnStay(PointEventArgs e)
    {
        WorldComponent.Sandbox.LeftPressed.Publish(true);
    }

    public override void OnCancel(PointEventArgs e)
    {
        WorldComponent.Sandbox.LeftPressed.Publish(false);
    }

    public override void OnEnd(PointEventArgs e)
    {
        WorldComponent.Sandbox.LeftPressed.Publish(false);
    }
}
