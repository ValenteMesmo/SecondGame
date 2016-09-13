using Common;

public class InputRightOnTouch : ColliderTouchBehaviour
{
    public override void OnStart(PointEventArgs e)
    {
        Player1Input.RightIsPressed = true;
    }

    public override void OnStay(PointEventArgs e)
    {
        Player1Input.RightIsPressed = true;
    }

    public override void OnCancel(PointEventArgs e)
    {
        Player1Input.RightIsPressed = false;
    }

    public override void OnEnd(PointEventArgs e)
    {
        Player1Input.RightIsPressed = false;
    }
}
