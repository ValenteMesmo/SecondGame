using Common;
using Common.GameComponents.PlayerComponents;

public class InputLeftOnTouch : ColliderTouchBehaviour
{
    public override void OnStart(PointEventArgs e)
    {
        Player1Input.LeftIsPressed = true;
    }

    public override void OnStay(PointEventArgs e)
    {
        Player1Input.LeftIsPressed = true;
    }

    public override void OnCancel(PointEventArgs e)
    {
        Player1Input.LeftIsPressed = false;
    }

    public override void OnEnd(PointEventArgs e)
    {
        Player1Input.LeftIsPressed = false;
    }
}
