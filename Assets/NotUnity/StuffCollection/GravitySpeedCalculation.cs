
public class GravitySpeedCalculation : Something
{
    VariablePosition Speed;
    GroundCollisionCalculation GroundCollisionCalculation;

    public GravitySpeedCalculation(
        VariablePosition speed, 
        GroundCollisionCalculation groundCollision)
    {
        Speed = speed;
        GroundCollisionCalculation = groundCollision;
    }

    public void Do(float timeSinceLastUpdate)
    {
        if(GroundCollisionCalculation.IsHittingTheGround)
        {
            Speed.Velocity_Y.SetValue(0);   
        }
        else
        {
            Speed.Velocity_Y.Add(-0.05f);
        }
    }
}
