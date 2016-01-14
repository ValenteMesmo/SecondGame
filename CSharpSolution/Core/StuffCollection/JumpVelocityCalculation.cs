
public class JumpVelocityCalculation : Something
{
    Thing Parent;

    const float acceleration = 5f;

    InputInfo input;
    GroundCollisionCalculation GroundCollisionCalculation;

    public JumpVelocityCalculation(
        InputInfo inputInfo,
        Thing parent,
        GroundCollisionCalculation groundCollision)
    {
        Parent = parent;
        input = inputInfo;
        GroundCollisionCalculation = groundCollision;
    }

    public void Do(float timeSinceLastUpdate)
    {
        if (input.RequestingJump && GroundCollisionCalculation.IsHittingTheGround)
        {
            Parent.Velocity_Y.SetValue(acceleration);
        }
    }
}
