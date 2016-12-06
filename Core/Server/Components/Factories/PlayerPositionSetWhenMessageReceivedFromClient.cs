using Server;
using System;

namespace Common.GameComponents.Factories
{
    internal class PlayerPositionSetWhenMessageReceivedFromClient
    {
        private readonly Collider Collider;
        private readonly Sandbox Sandbox;

        public PlayerPositionSetWhenMessageReceivedFromClient(Sandbox sandbox, Collider collider)
        {
            Sandbox = sandbox;
            Collider = collider;
                
            Sandbox.PositionReceivedFromClient.Subscribe(OnMessageReceived, Collider.Name);
        }

        private void OnMessageReceived(Position position)
        {
            Collider.X = position.X;
            Collider.Y = position.Y;
        }
    }
}