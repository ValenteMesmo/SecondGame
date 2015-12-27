using System.Collections.Generic;

public class Block : Thing
{
    public Block(ColliderContext collisionContext)
    {
        X = new FloatNumber(-100, 100, 0);
        Y = new FloatNumber(-100, 100, -2);

        var collider = new RectangleCollider(
                collisionContext,
                this,
                width: 0.8f,
                height: 0.8f,
                name: "Ground");

        Have(collider);
    }
}

public class Player : Thing
{
    public InputInfo input;

    public float Get_X()
    {
        return X.GetValue();
    }

    public float Get_Y()
    {
        return Y.GetValue();
    }

    public Player(ColliderContext collisionContext)
    {
        input = new InputInfo();
        X = new FloatNumber(-100, 100);
        Y = new FloatNumber(-100, 100);

        var rectangularCollider = new RectangleCollider(
            collisionContext,
            this,
            width: 1f,
            height: 1.55f,
            name: "Foot");

        var groundCollision = new GroundCollisionCalculation(rectangularCollider);

        Have(rectangularCollider)
        .Have(groundCollision)
        .Have(new PositionToAvoidColliderIntersection(this,rectangularCollider))
        .Have(new GravitySpeedCalculation(this, groundCollision))
        .Have(new JumpVelocityCalculation(input,this, groundCollision))
        .Have(new MovementVelocityCalculation(input, this));
    }
}

public class Thing
{
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

    private List<Something> toDoList;

    public Thing()
    {
        toDoList = new List<Something>();
        Velocity_X = new FloatNumber(-5f, 5f);
        Velocity_Y = new FloatNumber(-0.5f, 5f);
        Speed_X = new FloatNumber(-15f, 15f);
        Speed_Y = new FloatNumber(-15f, 15f);
        X = new FloatNumber(-100,100);
        Y = new FloatNumber(-100, 100);
    }

    public Thing Have(Something thing)
    {
        toDoList.Add(thing);
        return this;
    }

    public void DoIt(float timeSinceLastUpdate)
    {
        foreach (Something stuff in toDoList)
        {
            stuff.Do(timeSinceLastUpdate);
        }

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
