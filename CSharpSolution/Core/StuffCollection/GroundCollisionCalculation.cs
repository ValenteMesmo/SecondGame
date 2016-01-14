
public class GroundCollisionCalculation : Something
{
    private RectangleCollider Collider;

    public GroundCollisionCalculation(RectangleCollider collider)
    {
        Collider = collider;
    }

    public bool IsHittingTheGround { get; private set; }

    public void Do(float timeSinceLastUpdate)
    {
        IsHittingTheGround = false;
        foreach (CollisionInfo collision in Collider.CurrentCollisions)
        {
            if (collision.Collider.Name == "Ground" && collision.Below)
                IsHittingTheGround = true;
        }
    }
}
