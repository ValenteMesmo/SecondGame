using Common.GameComponents.MonsterComponents;
using Common.PubSubEngine;

namespace Common.GameComponents.Factories
{
    class MonsterFactory
    {
        private readonly Sandbox Sandbox;

        public MonsterFactory(Sandbox sandbox)
        {
            Sandbox = sandbox;
            Sandbox.AddMonster.Subscribe(CreateMonster);
        }

        private void CreateMonster(Position position)
        {
            new Monster(Sandbox, position);
        }
    }
}
