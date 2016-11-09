using Common.PubSubEngine;

namespace Common.GameComponents.MonsterComponents
{
    public class Monster
    {
        private readonly Sandbox Sandbox;
        public readonly Collider Collider;

        public Monster(Sandbox sandbox, Position position)
        {
            Sandbox = sandbox;
            Collider = new Collider(Sandbox, position.X, position.Y, 3, 3);
            Sandbox.WorldUpdate.Subscribe(Update);
            Sandbox.MonsterCreated.Publish(this);
        }

        private void Update()
        {
            Sandbox.MonsterUpdate.Publish(this, Collider.Name);
        }
    }
}
