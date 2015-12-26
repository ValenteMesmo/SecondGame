
public class MovementVelocityCalculation : Something
{
    VariablePosition SpeedCalculation;

    const float acceleration = 0.05f;

    InputInfo input;

    public MovementVelocityCalculation(
        InputInfo inputInfo, 
        VariablePosition speedCalculation)
    {
        SpeedCalculation = speedCalculation;
        input = inputInfo;
    }

    public void Do(float timeSinceLastUpdate)
    {
        if (input.RequestingLeftMovement)
            SpeedCalculation.Velocity_X.SetValue(-acceleration);
        else if (input.RequestingRightMovement)
            SpeedCalculation.Velocity_X.SetValue(acceleration);
        else
            SpeedCalculation.Velocity_X.SetValue(0);
    }
}
