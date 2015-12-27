using System.Collections.Generic;

public class RectangleCollider : Something
{
    public float X
    {
        get
        {
            return Parent.X.GetValue();
        }
    }
    public float Y
    {
        get
        {
            return Parent.Y.GetValue();
        }
    }

    public float Height = 0;
    public float Width = 0;
    public string Name = string.Empty;

    public List<CollisionInfo> CurrentCollisions = new List<CollisionInfo>();

    private ColliderContext ColliderContext;
    private Thing Parent;

    public RectangleCollider(
        ColliderContext colliderContext,
        Thing parent,
        float width,
        float height,
        string name)
    {
        ColliderContext = colliderContext;
        Width = width;
        Height = height;
        Name = name;
        Parent = parent;
        //TODO: validade ? to prevent duplication..
        ColliderContext.Colliders.Add(this);
    }

    public void Do(float timeSinceLastUpdate)
    {
        CurrentCollisions.Clear();

        var A = this;

        foreach (RectangleCollider B in ColliderContext.Colliders)
        {
            if (A != B
                && A.X < B.X + B.Width
                && A.X + A.Width > B.X
                && A.Y < B.Y + B.Height
                && A.Height + Y > B.Y)
            {
                var collision = new CollisionInfo(B);

                if (A.X > B.X)
                    collision.Right = true;
                else if (A.X < B.X)
                    collision.Left = true;

                if (A.Y > B.Y)
                    collision.Below = true;
                else if (A.Y < B.Y)
                    collision.Above = true;

                CurrentCollisions.Add(collision);
            }
        }
    }


}
