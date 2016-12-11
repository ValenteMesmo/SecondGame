using Client;
using Common.GameComponents.PlayerComponents;


namespace Common.GameComponents.Factories
{
    internal class ClientPlayerFactory
    {
        public readonly Sandbox Sandbox;

        public ClientPlayerFactory(Sandbox sandbox)
        {
            Sandbox = sandbox;
            Sandbox.ClientEvents_PlayerCreating.Subscribe(CreatePlayer);
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
            Sandbox.ClientEvents_PlayerCreated.Publish(player.Body);
        }
    }
}
