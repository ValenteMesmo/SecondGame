using Common.PubSubEngine;

namespace Common.GameComponents.Factories
{
    public class NetworkFactory
    {
        Sandbox Sandbox;
        public NetworkFactory(Sandbox sandbox)
        {
            Sandbox = sandbox;
            Sandbox.FoundNewIP.Subscribe(WhenIpIsFound);
        }

        private void WhenIpIsFound(string ip)
        {
            new MultiplayerMessageSender(Sandbox, ip, 1337);
        }
    }
}
