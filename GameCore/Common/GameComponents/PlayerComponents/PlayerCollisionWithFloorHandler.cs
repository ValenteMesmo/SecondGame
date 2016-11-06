using Common.PubSubEngine;

namespace Common.GameComponents.PlayerComponents
{
    public class PlayerCollisionWithFloorHandler
    {
        private readonly Sandbox Sandbox;
        private readonly Collider Body;

        public PlayerCollisionWithFloorHandler(Sandbox sandbox, Collider body)
        {
            Sandbox = sandbox;
            Body = body;
            sandbox.CollisionFromTheLeft.Subscribe(OnLeftCollision, Body.Name);
            sandbox.CollisionFromTheRight.Subscribe(OnRightCollision, Body.Name);
            sandbox.CollisionFromAbove.Subscribe(OnTopCollision, Body.Name);
            sandbox.CollisionFromBelow.Subscribe(OnBotCollision, Body.Name);
        }

        private void OnTopCollision(Collider other)
        {
        }

        private void OnBotCollision(Collider other)
        {
        }

        private void OnRightCollision(Collider other)
        {
            Body.X = other.X - Body.Width;
        }

        private void OnLeftCollision(Collider other)
        {
            Body.X = other.X + other.Width;
        }
    }
}
