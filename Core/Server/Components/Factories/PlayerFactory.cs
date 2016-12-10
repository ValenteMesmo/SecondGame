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
            new PlayerMoveBasedOnHorizontalSpeed(Sandbox);
            new PlayerJump(Sandbox);
            new PlayerGravityFall(Sandbox);
            new PlayerCollisionWithFloorHandler(Sandbox, player.Body);
            new PlayerWarpTopOnBotLimit(Sandbox);
            new PlayerWarpLeftOnRightLimit(Sandbox);
            new PlayerWarpRightOnLeftLimit(Sandbox);
            //new PlayerWalk(Sandbox);
            //new PlayerWalkInTheAir(Sandbox);            
            new PlayerPositionSetWhenMessageReceivedFromClient(Sandbox, player.Body);
            //Sandbox.PositionReceivedFromClient.Subscribe(pos =>
            //{
            //    player.Body.X = pos.X;
            //    player.Body.Y = pos.Y;
            //}, name);
        }
    }
}
