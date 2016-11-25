using Common.GameComponents.PlayerComponents;
using Common.PubSubEngine;

namespace Common.GameComponents.RemotePlayerComponents
{
    public class Host
    {
        public readonly Collider Body;
        private readonly Sandbox Sandbox;

        public Host(Sandbox sandbox, float x, float y)
        {
            Sandbox = sandbox;
            Body = new Collider(sandbox, x, y, 3, 6, GetType());            
            Sandbox.PlayerUpdateAfterCollisions.Subscribe(PlayerUpdate);
        }

        private void PlayerUpdate(Player player)
        {
            Sandbox.HostPositionUpdated.Publish(player.Body);
        }
    }
}
