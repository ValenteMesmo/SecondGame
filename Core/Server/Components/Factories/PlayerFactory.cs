using System;
using Common.GameComponents.PlayerComponents;
using Server;

namespace Common.GameComponents.Factories
{
    class PlayerFactory
    {
        public readonly Sandbox Sandbox;

        public PlayerFactory(Sandbox sandbox)
        {
            Sandbox = sandbox;
            Sandbox.ServerEvents_PlayerAdded.Subscribe(CreatePlayer);
        }

        private void CreatePlayer(string name)
        {
            var player = new Player(Sandbox, 0, 0, name);
            new PlayerMoveBasedOnHorizontalSpeed(Sandbox, player.Body.Name);
            new PlayerJump(Sandbox, player.Body.Name);
            new PlayerGravityFall(Sandbox, player.Body.Name);
            new PlayerCollisionWithFloorHandler(Sandbox, player.Body);
            new PlayerWarpTopOnBotLimit(Sandbox, player.Body.Name);
            new PlayerWarpLeftOnRightLimit(Sandbox, player.Body.Name);
            new PlayerWarpRightOnLeftLimit(Sandbox, player.Body.Name);
            new PlayerWalk(Sandbox, player.Body.Name);
            new PlayerWalkInTheAir(Sandbox, player.Body.Name);            
            //new PlayerPositionSetWhenMessageReceivedFromClient(Sandbox, player.Body);
            //Sandbox.PositionReceivedFromClient.Subscribe(pos =>
            //{
            //    player.Body.X = pos.X;
            //    player.Body.Y = pos.Y;
            //}, name);
        }
    }
}
