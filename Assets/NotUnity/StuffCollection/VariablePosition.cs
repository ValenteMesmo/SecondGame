
public class VariablePosition : Something
{
    //RectangleCollider Collider;    

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

    public VariablePosition(
        FloatNumber x,
        FloatNumber y)
    {
        Velocity_X = new FloatNumber(-5f, 5f);
        Velocity_Y = new FloatNumber(-0.5f, 5f);
        Speed_X = new FloatNumber(-15f, 15f);
        Speed_Y = new FloatNumber(-15f, 15f);
        X = x;
        Y = y;
    }

    public void Do(float timeSinceLastUpdate)
    {
        //foreach (var collision in Collider.CurrentCollisions)
        //{
        //    if (collision.Below)
        //    {
        //        Y.SetValue(collision.Collider.Y + collision.Collider.Height);
        //    }

        //    if (collision.Above)
        //    {
        //        Y.SetValue(collision.Collider.Y - Collider.Height);
        //    }
        //}

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


}
