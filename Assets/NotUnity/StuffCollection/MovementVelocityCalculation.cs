
public class MovementVelocityCalculation : Something
{
    Thing Parent;

    const float acceleration = 0.05f;

    InputInfo input;

    public MovementVelocityCalculation(
        InputInfo inputInfo, 
        Thing parent)
    {
        Parent = parent;
        input = inputInfo;
    }

    public void Do(float timeSinceLastUpdate)
    {
        if (input.RequestingLeftMovement)
            Parent.Velocity_X.SetValue(-acceleration);
        else if (input.RequestingRightMovement)
            Parent.Velocity_X.SetValue(acceleration);
        else
            Parent.Velocity_X.SetValue(0);
    }
}
