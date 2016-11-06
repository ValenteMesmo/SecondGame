using Common.GameComponents.PlayerComponents;
using Common.PubSubEngine;

namespace Common
{
    public class World
    {
        public readonly Sandbox Sandbox = new Sandbox();

        public void AddPlayer(float x, float y)
        {
            new Player(Sandbox, x, y);
            //Sandbox.Pub(EventNames.PLAYER_CREATION_REQUESTED, new Position(x, y));
        }

        public void AddMonster(float x, float y)
        {
            Sandbox.MonsterCreationRequested.Publish(new Position(x, y));
        }

        public void Update()
        {
            Sandbox.WorldUpdate.Publish();
            Sandbox.OnCollisionDetectionRequested.Publish();
        }
    }
}