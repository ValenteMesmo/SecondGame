
public class PositionToAvoidColliderIntersection : Something
{
    Thing Parent;
    RectangleCollider Collider;
    public PositionToAvoidColliderIntersection( 
        Thing parent,
        RectangleCollider collider)
    {
        Parent = parent;
        Collider = collider;
    }

    public void Do(float timeSinceLastUpdate)
    {
        foreach (var collision in Collider.CurrentCollisions)
        {
            if (collision.Below)
            {
                Parent.Y.SetValue(collision.Collider.Y + collision.Collider.Height);
            }

            if (collision.Above)
            {
                Parent.Y.SetValue(collision.Collider.Y - Collider.Height);
            }
        }
    }
}
