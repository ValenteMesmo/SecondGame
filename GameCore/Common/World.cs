using System;
using Common.GameComponents.PlayerComponents;
using Common.PubSubEngine;
using Common.GameComponents.MonsterComponents;

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
        }

        private void CreateMonster(Position obj)
        {
            new Monster(Sandbox, obj);
        }

        private void CreatePlayer(Position position)
        {
            var player = new Player(Sandbox, position.X, position.Y);
            new PlayerHorizontalMovement(Sandbox);
            new PlayerJump(Sandbox);
            new PlayerGravityFall(Sandbox);
            new PlayerCollisionWithFloorHandler(Sandbox, player.Body);
            new PlayerWarpTopOnBotLimit(Sandbox);
            new PlayerWarpLeftOnRightLimit(Sandbox);
            new PlayerWarpRightOnLeftLimit(Sandbox);
        }

        public void Update()
        {
            Sandbox.WorldUpdate.Publish();
            Sandbox.OnCollisionDetectionRequested.Publish();
            Sandbox.WorldUpdateAfterCollisions.Publish();
        }
    }
}