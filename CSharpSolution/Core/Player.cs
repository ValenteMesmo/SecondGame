public class Player : Thing
{
    public InputInfo input;
    private GroundCollisionCalculation groundCollision;

    public float Get_X()
    {
        return X.GetValue();
    }

    public float Get_Y()
    {
        return Y.GetValue();
    }

    public bool IsTouchingTheGround() { return groundCollision.IsHittingTheGround; }

    public Player(string id, ColliderContext collisionContext):base(id)
    {
        input = new InputInfo();

        var rectangularCollider = new RectangleCollider(
            collisionContext,
            this,
            width: 1f,
            height: 1.55f,
            name: "Foot");

        groundCollision = new GroundCollisionCalculation(rectangularCollider);

        Have(rectangularCollider)
        .Have(groundCollision)
        .Have(new PositionToAvoidColliderIntersection(this, rectangularCollider))
        //.Have(new GravitySpeedCalculation(this, groundCollision))
        .Have(new JumpVelocityCalculation(input, this, groundCollision))
        .Have(new MovementVelocityCalculation(input, this));
    }
}
