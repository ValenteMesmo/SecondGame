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
            Sandbox.ClientEvents_PlayerAdded.Subscribe(CreatePlayer);
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
            //new PlayerWalk(Sandbox);
            //new PlayerWalkInTheAir(Sandbox);            
            new PlayerPositionSetWhenMessageReceivedFromClient(Sandbox, player.Body);
        }
    }
}
