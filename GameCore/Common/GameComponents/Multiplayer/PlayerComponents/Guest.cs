using System;
using Common.GameComponents.PlayerComponents;
using Common.PubSubEngine;

namespace Common.GameComponents.Multiplayer
{
    public class Guest
    {
        public readonly Collider Body;
        private readonly Sandbox Sandbox;

        public Guest(Sandbox sandbox, float x, float y)
        {
            Sandbox = sandbox;
            Body = new Collider(sandbox, x, y, 3, 6, GetType());
            Sandbox.PlayerUpdateAfterCollisions.Subscribe(PlayerUpdate);
        }

        private void PlayerUpdate(Player obj)
        {
            Sandbox.GuestPositionUpdated.Publish(obj.Body);
        }        
    }
}
