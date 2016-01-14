public class CollisionInfo
{
    public RectangleCollider Collider;
    public bool Above;
    public bool Below;
    public bool Right;
    public bool Left;

    public CollisionInfo(RectangleCollider target)
    {
        Collider = target;
    }

    public override string ToString()
    {
        return string.Format(
            "CollisonInfo: {{ target: {0}, Above: {1}, Below: {2}, Right: {3}, Left: {4} }}",
            Collider.Name, Above, Below, Right, Left);
    }
}
