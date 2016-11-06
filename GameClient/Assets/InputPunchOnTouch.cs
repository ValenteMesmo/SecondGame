using Common;
using Common.GameComponents.PlayerComponents;

public class InputPunchOnTouch : ColliderTouchBehaviour
{
    public override void OnStart(PointEventArgs e)
    {
        Player1Input.PunchPressed = true;
    }

    public override void OnStay(PointEventArgs e)
    {
        Player1Input.PunchPressed = true;
    }

    public override void OnCancel(PointEventArgs e)
    {
        Player1Input.PunchPressed = false;
    }

    public override void OnEnd(PointEventArgs e)
    {
        Player1Input.PunchPressed = false;
    }
}
