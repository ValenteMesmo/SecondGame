
using Common.GameComponents.PlayerComponents;
using System;

namespace Common.GameComponents
{
    public class MultiplayerPortal : IDisposable
    {
        public Collider Collider { get; }
        public Sandbox Sandbox { get; }
        public string Ip { get; }

        public MultiplayerPortal(Sandbox sandbox, string ip, float x, float y)
        {
            Sandbox = sandbox;
            Ip = ip;
            Collider = new Collider(sandbox, x, y, 3, 3, GetType(), true);
            Sandbox.CollisionFromAnySide.Subscribe(OnCollision, Collider.Name);
            Sandbox.PortalCreated.Publish(Ip);
            Sandbox.OtherPlayerEnteredAsTheGuest.Subscribe(Dispose, Ip);
            Sandbox.OtherPlayerEnteredAsTheHost.Subscribe(Dispose, Ip);
        }

        private void OnCollision(Collider otherCollider)
        {
            if (otherCollider.Parent == typeof(Player))
            {
                Sandbox.YouEnteredThePortal.Publish(this);
            }
        }

        public void Dispose()
        {
            Sandbox.OtherPlayerEnteredAsTheGuest.Unsubscribe(Dispose, Ip);
            Sandbox.OtherPlayerEnteredAsTheHost.Unsubscribe(Dispose, Ip);
            Sandbox.ColliderDestroyed.Publish(Collider);
            Sandbox.CollisionFromAnySide.Unsubscribe(OnCollision, Collider.Name);
            Sandbox.PortalDisposed.Publish(Ip);
        }
    }
}
