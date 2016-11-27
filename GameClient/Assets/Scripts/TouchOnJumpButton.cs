public class TouchOnJumpButton : ColliderTouchBehaviour
{
    public override void OnStart(PointEventArgs e)
    {
        WorldComponent.Sandbox.UpPressed.Publish(true);
    }

    public override void OnStay(PointEventArgs e)
    {
        WorldComponent.Sandbox.UpPressed.Publish(true);
    }

    public override void OnCancel(PointEventArgs e)
    {
        WorldComponent.Sandbox.UpPressed.Publish(false);
    }

    public override void OnEnd(PointEventArgs e)
    {
        WorldComponent.Sandbox.UpPressed.Publish(false);
    }
}
