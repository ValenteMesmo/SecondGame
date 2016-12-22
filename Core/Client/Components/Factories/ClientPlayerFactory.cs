using Client;
using Client.Components;
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
            Sandbox.Log.Publish("new player  " + player.Body.Name);
            new PlayerMoveBasedOnHorizontalSpeed(Sandbox,player.Body.Name);
            new PlayerJump(Sandbox, player.Body.Name);
            new PlayerGravityFall(Sandbox, player.Body.Name);
            new PlayerCollisionWithFloorHandler(Sandbox, player.Body);
            new PlayerWarpTopOnBotLimit(Sandbox, player.Body.Name);
            new PlayerWarpLeftOnRightLimit(Sandbox, player.Body.Name);
            new PlayerWarpRightOnLeftLimit(Sandbox, player.Body.Name);
            new PlayerWalk(Sandbox, player.Body.Name);
            new PlayerWalkInTheAir(Sandbox, player.Body.Name);
            ////todo: dispose
            //new ListenMessagesFromServer(Sandbox, 1338, player.Body.Name);
            ////todo: dispose
            //new SendMessagesToServer(Sandbox, "192.168.0.3", 1337);
        }
    }
}
