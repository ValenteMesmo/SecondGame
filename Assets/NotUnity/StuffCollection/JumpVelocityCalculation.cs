
public class JumpVelocityCalculation : Something
{
    VariablePosition position;

    const float acceleration = 1f;

    InputInfo input;
    GroundCollisionCalculation GroundCollisionCalculation;

    public JumpVelocityCalculation(
        InputInfo inputInfo,
        VariablePosition speedCalculation,
        GroundCollisionCalculation groundCollision)
    {
        position = speedCalculation;
        input = inputInfo;
        GroundCollisionCalculation = groundCollision;
    }

    public void Do(float timeSinceLastUpdate)
    {
        if (input.RequestingJump && GroundCollisionCalculation.IsHittingTheGround)
        {
            position.Velocity_Y.SetValue(acceleration);
        }
    }
}
