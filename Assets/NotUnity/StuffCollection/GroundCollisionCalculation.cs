
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
            //UnityEngine.Debug.Log( collision.ToString());

            if (collision.Collider.Name == "Ground")
                IsHittingTheGround = true;
        }
    }
}
