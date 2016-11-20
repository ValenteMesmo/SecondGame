using Common.PubSubEngine;
using Common.GameComponents.PlayerComponents;

namespace Common.GameComponents
{
    public class MultiplayerPortal
    {
        public Collider Collider { get; }
        public Sandbox Sandbox { get; }
        public string Ip { get; }

        public MultiplayerPortal(Sandbox sandbox, string ip, float x, float y)
        {
            Sandbox = sandbox;
            Collider = new Collider(sandbox, x, y, 3, 3, GetType(), true);
            sandbox.CollisionFromAnySide.Subscribe(OnCollision, Collider.Name);
            Ip = ip;
        }

        private void OnCollision(Collider otherCollider)
        {
            if (otherCollider.Parent == typeof(Player))
            {
                Sandbox.AddRemotePlayer.Publish(Ip);
                Sandbox.SendNetwokMessage.Publish("Connected", Ip);
            }
        }
    }
}
