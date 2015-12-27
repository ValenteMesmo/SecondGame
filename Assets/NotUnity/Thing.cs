using System.Collections.Generic;

public class Thing
{
    public FloatNumber Velocity_X { get; set; }
    public FloatNumber Velocity_Y { get; set; }

    /// <summary>
    /// Avoid changing this value. 
    /// </summary>
    public FloatNumber X;
    /// <summary>
    /// Avoid changing this value. 
    /// </summary>
    public FloatNumber Y;

    private FloatNumber Speed_X;
    private FloatNumber Speed_Y;

    private List<Something> toDoList;

    public Thing()
    {
        toDoList = new List<Something>();

        Velocity_X = new FloatNumber(-GameConstants.WalkingVelocity, GameConstants.WalkingVelocity);
        Velocity_Y = new FloatNumber(-GameConstants.Gravity, GameConstants.JumpForce);

        Speed_X = new FloatNumber(-GameConstants.MaxSpeed_X, GameConstants.MaxSpeed_X);
        Speed_Y = new FloatNumber(-GameConstants.MaxSpeed_Y, GameConstants.MaxSpeed_Y);

        X = new FloatNumber(-GameConstants.MaxDistance_X, GameConstants.MaxDistance_X);
        Y = new FloatNumber(-GameConstants.MaxDistance_Y, GameConstants.MaxDistance_Y);
    }

    public Thing Have(Something thing)
    {
        toDoList.Add(thing);
        return this;
    }

    public void DoIt(float timeSinceLastUpdate)
    {
        foreach (Something stuff in toDoList)
        {
            stuff.Do(timeSinceLastUpdate);
        }

        if (Velocity_X.GetValue() == 0)
            Speed_X.SetValue(0);
        else
            Speed_X.Add(Velocity_X.GetValue() * timeSinceLastUpdate);

        if (Velocity_Y.GetValue() == 0)
            Speed_Y.SetValue(0);
        else
            Speed_Y.Add(Velocity_Y.GetValue() * timeSinceLastUpdate);

        X.Add(Speed_X);
        Y.Add(Speed_Y);
    }

    public override string ToString()
    {
        return string.Format(
@"Speed_X: {0}
Speed_Y: {1}", Speed_X.GetValue(), Speed_Y.GetValue());
    }
}