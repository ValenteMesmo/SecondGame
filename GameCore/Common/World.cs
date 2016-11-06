using Common.GameComponents.PlayerComponents;
using Common.PubSubEngine;

namespace Common
{
    public class World
    {
        public readonly Sandbox Sandbox;

        public World()
        {
            Sandbox = new Sandbox();
            Sandbox.AddPlayer.Subscribe(position =>
                new Player(Sandbox, position.X, position.Y));
            //Sandbox.AddMonster.Subscribe(position =>
            //    new Monster(Sandbox, position.X, position.Y));
        }

        public void Update()
        {
            Sandbox.WorldUpdate.Publish();
            Sandbox.OnCollisionDetectionRequested.Publish();
        }
    }
}