using Common.PubSubEngine;
using Common.GameComponents.PlayerComponents;
using System;
using Common.GameComponents.RemotePlayerComponents;

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
            Sandbox.CloseThePortal.Subscribe(Dispose, Ip);
            Sandbox.PortalCreated.Publish(Ip);
        }

        private void OnCollision(Collider otherCollider)
        {
            if (otherCollider.Parent == typeof(Player))
            {
                new HostPlayer(Sandbox, 0, 0);                
                Sandbox.AddRemotePlayer.Publish(Ip);
                Sandbox.SendNetwokMessage.Publish("Connected", Ip);
                Sandbox.CloseThePortal.Publish(Ip);
            }
        }

        public void Dispose()
        {
            Sandbox.CollisionFromAnySide.Unsubscribe(OnCollision, Collider.Name);
            Sandbox.CloseThePortal.Unsubscribe(Dispose, Ip);
        }
    }
}
