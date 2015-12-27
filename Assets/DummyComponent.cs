using UnityEngine;
using System.Collections;

public class DummyComponent : MonoBehaviour
{
    public GameLoop game;
    Player player;

    void Start()
    {
        var world = game.World;

        player = new Player(world.CollisionContext);
        var block = new Block(world.CollisionContext);

        world.AddThing(player);
        world.AddThing(block);
    }

    void Update()
    {
        player.input.RequestingLeftMovement = Input.GetAxis("Horizontal") < 0;
        player.input.RequestingRightMovement = Input.GetAxis("Horizontal") > 0;
        player.input.RequestingJump = Input.GetButton("Jump");
    }
}
