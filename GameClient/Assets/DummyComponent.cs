﻿//using UnityEngine;

//public class DummyComponent : MonoBehaviour
//{
//    public GameLoop game;
//    Player player;

//    void Start()
//    {
//        var world = game.World;

//        //player = new Player(world.CollisionContext);
//        //var player2 = new Player(world.CollisionContext);
//        //player2.X.SetValue(2);

//        //world.AddThing(player);
//        //world.AddThing(player2);

//        //for (int i = 0; i < 20; i++)
//        //{
//        //    var block = new Block(world.CollisionContext);
//        //    block.Y.SetValue(-2);
//        //    block.X.SetValue(i * -0.8f);
//        //    world.AddThing(block);
//        //}

//        //for (int i = 1; i < 20; i++)
//        //{
//        //    var block = new Block(world.CollisionContext);
//        //    block.Y.SetValue(-2);
//        //    block.X.SetValue(i * 0.8f);
//        //    world.AddThing(block);
//        //}

//    }

//    void Update()
//    {
//        player.input.RequestingLeftMovement = Input.GetAxis("Horizontal") < 0;
//        player.input.RequestingRightMovement = Input.GetAxis("Horizontal") > 0;
//        player.input.RequestingJump = Input.GetButton("Jump");        
//    }
//}