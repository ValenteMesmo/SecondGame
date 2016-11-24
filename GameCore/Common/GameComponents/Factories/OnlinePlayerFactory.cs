using Common.GameComponents.RemotePlayerComponents;
using Common.PubSubEngine;

namespace Common.GameComponents.Factories
{
    public class OnlinePlayerFactory
    {
        private readonly Sandbox Sandbox;

        public OnlinePlayerFactory(Sandbox sandbox)
        {
            Sandbox = sandbox;
            Sandbox.AddRemotePlayer.Subscribe(RemotePlayerCreationRequested);           
        }

        private void RemotePlayerCreationRequested(string ip)
        {
            new Host(Sandbox, 0, 0);
        }
    }
}
