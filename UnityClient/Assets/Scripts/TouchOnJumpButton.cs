using System;
using Common.GameComponents.PlayerComponents;

public class TouchOnJumpButton : ColliderTouchBehaviour
{
    void Start()
    {
        WorldComponent.Sandbox.PlayerUpdateAfterCollisions.Subscribe(OnPlayerUpdated);
        WorldComponent.Sandbox.Log.Publish("hmmm ");
    }

    string pname = null;
    private void OnPlayerUpdated(Player obj)
    {
        if (pname == null)
        {
            pname = obj.Body.Name;
            WorldComponent.Sandbox.Log.Publish("hmmm 2      " + obj.Body.Name);
        }
    }

    public override void OnStart(PointEventArgs e)
    {
        WorldComponent.Sandbox.Log.Publish("hmmm 3");

        if (pname != null)
            WorldComponent.Sandbox.UpPressed.Publish(true, pname);

        WorldComponent.Sandbox.Log.Publish("jump start " + pname);
    }

    public override void OnStay(PointEventArgs e)
    {
        if (pname != null)
            WorldComponent.Sandbox.UpPressed.Publish(true, pname);
    }

    public override void OnCancel(PointEventArgs e)
    {
        if (pname != null)
            WorldComponent.Sandbox.UpPressed.Publish(false, pname);
    }

    public override void OnEnd(PointEventArgs e)
    {
        if (pname != null)
            WorldComponent.Sandbox.UpPressed.Publish(false, pname);
        WorldComponent.Sandbox.Log.Publish("jump end   " + pname);
    }
}
