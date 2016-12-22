using Common.GameComponents.PlayerComponents;
using UnityEngine;

public class TouchOnLeftButton : ColliderTouchBehaviour
{
    void Start()
    {
        WorldComponent.Sandbox.PlayerUpdateAfterCollisions.Subscribe(OnPlayerUpdated);
    }

    string pname = null;
    private void OnPlayerUpdated(Player obj)
    {
        if (pname == null)
            pname = obj.Body.Name;
    }

    public override void OnStart(PointEventArgs e)
    {   
        if (pname != null)
            WorldComponent.Sandbox.LeftPressed.Publish(true, pname);
    }

    public override void OnStay(PointEventArgs e)
    {
        if (pname != null)
            WorldComponent.Sandbox.LeftPressed.Publish(true, pname);
    }

    public override void OnCancel(PointEventArgs e)
    {
        if (pname != null)
            WorldComponent.Sandbox.LeftPressed.Publish(false, pname);
    }

    public override void OnEnd(PointEventArgs e)
    {
        if (pname != null)
            WorldComponent.Sandbox.LeftPressed.Publish(false, pname);
    }
}