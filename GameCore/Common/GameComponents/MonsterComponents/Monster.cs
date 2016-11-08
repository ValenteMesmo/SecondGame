using Common.PubSubEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        }

        private void Update()
        {
            Sandbox.MonsterUpdate.Publish(this, Collider.Name);
        }
    }
}
