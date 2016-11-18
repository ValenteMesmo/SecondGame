using Common.GameComponents.PlayerComponents;
using Common.PubSubEngine;
using Common.GameComponents.MonsterComponents;
using Common.GameComponents;
using NetworkStuff;
using System;

namespace Common
{
    public class World
    {
        public readonly Sandbox Sandbox;

        public World()
        {
            Sandbox = new Sandbox();
            new CollisionChecker(Sandbox);
            Sandbox.AddPlayer.Subscribe(CreatePlayer);
            Sandbox.AddMonster.Subscribe(CreateMonster);
            Sandbox.AddGround.Subscribe(CreateGround);
            Sandbox.AddMultiplayerPortal.Subscribe(CreatePortal);
            Sandbox.PlayerEnteredThePortal.Subscribe(PlayerEnteredMultiplayerPortal);
        }

        private void PlayerEnteredMultiplayerPortal(MultiplayerPortal portal)
        {
            var client = Factory.CreateClient(portal.Ip, 1337);
            client.Listen(OnMessageReceivedFromServer);
            client.SendMessage("hello");
        }

        private void OnMessageReceivedFromServer(string message, Address sourceAddress)
        {

        }

        private void CreatePortal(string ip)
        {
            new MultiplayerPortal(Sandbox, ip, 3, 3);
            var host = Factory.CreateHost(1337);
            host.Listen(OnMessageReceivedFromCLient);
        }

        private void OnMessageReceivedFromCLient(string message, Address sourceAddress)
        {
            //if(message == "hello")
            //    Sandbox.AddRemotePlayer
        }

        private void CreateGround(Dimension dimension)
        {
            new Ground(Sandbox, dimension);
        }

        private void CreateMonster(Position position)
        {
            new Monster(Sandbox, position);
        }

        private void CreatePlayer(Position position)
        {
            var player = new Player(Sandbox, position.X, position.Y);
            new PlayerMoveBasedOnHorizontalSpeed(Sandbox);
            new PlayerJump(Sandbox);
            new PlayerGravityFall(Sandbox);
            new PlayerCollisionWithFloorHandler(Sandbox, player.Body);
            new PlayerWarpTopOnBotLimit(Sandbox);
            new PlayerWarpLeftOnRightLimit(Sandbox);
            new PlayerWarpRightOnLeftLimit(Sandbox);
            new PlayerWalk(Sandbox);
            new PlayerWalkInTheAir(Sandbox);
        }

        public void Update()
        {
            Sandbox.WorldUpdate.Publish();
            Sandbox.OnCollisionDetectionRequested.Publish();
            Sandbox.WorldUpdateAfterCollisions.Publish();
        }
    }
}