public class Block : Thing
{
    public Block(ColliderContext collisionContext)
    {
        X = new FloatNumber(-GameConstants.MaxDistance_X, GameConstants.MaxDistance_X);
        Y = new FloatNumber(-GameConstants.MaxDistance_Y, GameConstants.MaxDistance_Y);

        var collider = new RectangleCollider(
                collisionContext,
                this,
                width: 0.8f,
                height: 0.8f,
                name: "Ground");

        Have(collider);
    }
}