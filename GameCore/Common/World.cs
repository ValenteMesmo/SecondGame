using Common.GameComponents.PlayerComponents;
using Common.PubSubEngine;
using Common.GameComponents.MonsterComponents;
using Common.GameComponents;
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

        private void PlayerEnteredMultiplayerPortal(MultiplayerPortal obj)
        {
            var client = NetworkStuff.Factory.CreateClient(1337, 1338);
            //client.Listen();
        }

        private void CreatePortal(string ip)
        {
            new MultiplayerPortal(Sandbox, ip, 3, 3);
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