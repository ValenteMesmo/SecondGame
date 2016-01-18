public class Block : Thing
{
    public Block(string id, ColliderContext collisionContext) : base(id)
    {
        var collider = new RectangleCollider(
                collisionContext,
                this,
                width: 0.8f,
                height: 0.8f,
                name: "Ground");

        Have(collider);
    }
}