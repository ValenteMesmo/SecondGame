using Common.PubSubEngine;

namespace Common.GameComponents.PlayerComponents
{
    public class Player
    {
        public Collider Body { get; }
        Sandbox Sandbox;

        public Player(Sandbox sandbox, float x, float y)
        {
            Sandbox = sandbox;
            Body = new Collider(sandbox, x, y, 3, 6);

            Sandbox.WorldUpdate.Subscribe(Update);
        }

        private void Update()
        {
            Sandbox.PlayerUpdate.Publish(this);
        }
    }
}