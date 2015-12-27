
public class GravitySpeedCalculation : Something
{
    GroundCollisionCalculation GroundCollisionCalculation;
    Thing Parent;

    public GravitySpeedCalculation(
        Thing parent,
        GroundCollisionCalculation groundCollision)
    {
        Parent = parent;
        GroundCollisionCalculation = groundCollision;
    }

    public void Do(float timeSinceLastUpdate)
    {
        if (GroundCollisionCalculation.IsHittingTheGround)
        {
            Parent.Velocity_Y.SetValue(0);
        }
        else
        {
            Parent.Velocity_Y.Add(-0.05f);
        }
    }
}
