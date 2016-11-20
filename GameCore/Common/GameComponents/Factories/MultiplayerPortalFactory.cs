using Common.PubSubEngine;

namespace Common.GameComponents.Factories
{
    public class MultiplayerPortalFactory
    {
        private readonly Sandbox Sandbox;

        public MultiplayerPortalFactory(Sandbox sandbox)
        {
            Sandbox = sandbox;
            Sandbox.AddMultiplayerPortal.Subscribe(CreatePortal);
        }

        private void CreatePortal(string ip)
        {
            new MultiplayerPortal(Sandbox, ip, 3, 3);
        }
    }
}
