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
            Sandbox.AddPlayer.Subscribe(CreatePlayer);
            //Sandbox.AddMonster.Subscribe(position =>
            //    new Monster(Sandbox, position.X, position.Y));
        }

        private void CreatePlayer(Position position)
        {
            new Player(Sandbox, position.X, position.Y);
            new PlayerHorizontalMovement(Sandbox);
            new PlayerVerticalMovement(Sandbox);
        }

        public void Update()
        {
            Sandbox.WorldUpdate.Publish();
            Sandbox.OnCollisionDetectionRequested.Publish();
        }
    }
}