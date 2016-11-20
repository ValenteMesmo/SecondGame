using Common.PubSubEngine;

namespace Common.GameComponents.PlayerComponents
{
    public class Player
    {
        public float VerticalSpeed = 0f;
        public float HorizontalSpeed = 0f;

        public Collider Body { get; }
        public bool Grounded { get; private set; }

        Sandbox Sandbox;

        public Player(Sandbox sandbox, float x, float y)
        {
            Sandbox = sandbox;
            Body = new Collider(sandbox, x, y, 3, 6,
                GetType());

            Sandbox.OnWorldUpdate.Subscribe(Update);
            Sandbox.CollisionFromBelow.Subscribe(OnCollisionFromBelow, Body.Name);
            Sandbox.OnWorldUpdateAfterCollisions.Subscribe(LateUpdate);
        }

        private void OnCollisionFromBelow(Collider obj)
        {
            VerticalSpeed = 0;
            Grounded = true;
        }

        private void LateUpdate()
        {
            Sandbox.PlayerUpdateAfterCollisions.Publish(this);
        }

        private void Update()
        {
            Sandbox.PlayerUpdate.Publish(this);
            Grounded = false;
        }
    }
}