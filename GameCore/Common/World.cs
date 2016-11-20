using Common.PubSubEngine;
using Common.GameComponents.Factories;
using System;

namespace Common
{
    public class World
    {
        public readonly Sandbox Sandbox;

        public World()
        {
            Sandbox = new Sandbox();
            new CollisionChecker(Sandbox);            
            new PlayerFactory(Sandbox);
            new GroundFactory(Sandbox);
            new MonsterFactory(Sandbox);
            new MultiplayerPortalFactory(Sandbox);
            new OnlinePlayerFactory(Sandbox);
        }

        public void Update()
        {
            Sandbox.OnWorldUpdate.Publish();
            Sandbox.OnCollisionDetectionRequested.Publish();
            Sandbox.OnWorldUpdateAfterCollisions.Publish();
        }
    }
}