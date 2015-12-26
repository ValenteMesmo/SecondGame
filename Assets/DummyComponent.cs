using UnityEngine;
using System.Collections;

public class DummyComponent : MonoBehaviour
{
    public GameLoop game;
    World world;
    InputInfo input;
    Thing player;
    VariablePosition position;

    void Start()
    {
        world = game.World;
        player = new Thing();
        input = new InputInfo();

        var unityCollider = GetComponent<BoxCollider2D>();

        position = new VariablePosition(
            new FloatNumber(-100, 100),
            new FloatNumber(-100, 100));
        var rectangularCollider = new RectangleCollider(
                player,
                world.CollisionContext,
                position,
                width: unityCollider.bounds.size.x,
                height: unityCollider.bounds.size.y,
                name: "Foot");
        
        var groundCollision = new GroundCollisionCalculation(rectangularCollider);

        player
            .Have(rectangularCollider)
            .Have(groundCollision)
            .Have(new PositionToAvoidColliderIntersection(position, rectangularCollider))
            .Have(new GravitySpeedCalculation(position, groundCollision))
            .Have(new JumpVelocityCalculation(input, position, groundCollision))
            .Have(new MovementVelocityCalculation(input, position))
            .Have(position)
            ;

        Destroy(unityCollider);

        world.AddThing(player);
    }

    void Update()
    {
        input.RequestingLeftMovement = Input.GetAxis("Horizontal") < 0;
        input.RequestingRightMovement = Input.GetAxis("Horizontal") > 0;
        input.RequestingJump = Input.GetButton("Jump");

        transform.position = new Vector2(
            position.X.GetValue(),
            position.Y.GetValue());
    }
}
