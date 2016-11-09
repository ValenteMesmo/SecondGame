using System;
using Common.PubSubEngine;

namespace Common.GameComponents.PlayerComponents
{
    public class Player
    {
        public float VerticalSpeed;

        public Collider Body { get; }
        Sandbox Sandbox;

        public Player(Sandbox sandbox, float x, float y)
        {
            Sandbox = sandbox;
            Body = new Collider(sandbox, x, y, 3, 6);

            Sandbox.WorldUpdate.Subscribe(Update);
            Sandbox.WorldUpdateAfterCollisions.Subscribe(LateUpdate);
        }

        private void LateUpdate()
        {
            Sandbox.PlayerUpdateAfterCollisions.Publish(this);
        }

        private void Update()
        {
            Sandbox.PlayerUpdate.Publish(this);
        }
    }
}