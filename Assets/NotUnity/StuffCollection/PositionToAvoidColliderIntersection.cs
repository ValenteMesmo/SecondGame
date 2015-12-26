
public class PositionToAvoidColliderIntersection : Something
{
    VariablePosition Position;
    RectangleCollider Collider;
    public PositionToAvoidColliderIntersection( 
        VariablePosition position,
        RectangleCollider collider)
    {
        Position = position;
        Collider = collider;
    }

    public void Do(float timeSinceLastUpdate)
    {
        foreach (var collision in Collider.CurrentCollisions)
        {
            if (collision.Below)
            {
                Position.Y.SetValue(collision.Collider.Y + collision.Collider.Height);
            }

            if (collision.Above)
            {
                Position.Y.SetValue(collision.Collider.Y - Collider.Height);
            }
        }
    }
}
