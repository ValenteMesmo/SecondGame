using UnityEngine;

public class DummyComponent : MonoBehaviour
{
    public GameLoop game;
    Player player;

    void Start()
    {
        var world = game.World;

        player = new Player(world.CollisionContext);

        world.AddThing(player);

        for (int i = 0; i < 15; i++)
        {
            world.AddThing(new Block(world.CollisionContext)
            {
                Y = new FloatNumber(-10f, 10f, -2f),
                X = new FloatNumber(-10f, 10f, i * -0.8f)
            });
        }

    }

    void Update()
    {
        player.input.RequestingLeftMovement = Input.GetAxis("Horizontal") < 0;
        player.input.RequestingRightMovement = Input.GetAxis("Horizontal") > 0;
        player.input.RequestingJump = Input.GetButton("Jump");
    }
}
