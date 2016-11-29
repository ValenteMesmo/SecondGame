using Common.GameComponents;
using Common.GameComponents.Factories;
using Common.GameComponents.Multiplayer;

using System;
using System.Collections.Generic;

namespace Common
{
    public class World : IDisposable
    {
        public readonly Sandbox Sandbox;
        private readonly List<IDisposable> Disposables;
        public int LoopCount { get; private set; }

        public World()
        {
            Disposables = new List<IDisposable>();
            Sandbox = new Sandbox();
            new CollisionChecker(Sandbox);            
            new PlayerFactory(Sandbox);
            new GroundFactory(Sandbox);
            new MonsterFactory(Sandbox);
            new MultiplayerPortalFactory(Sandbox);
            new NetworkFactory(Sandbox);
            Disposables.Add(new FindPlayersOnLocalAreaNetwork(Sandbox));
            Disposables.Add(new MultiplayerMessageListener(Sandbox, 1337));
        }

        public void Dispose()
        {
            foreach (var item in Disposables)
            {
                item.Dispose();
            }
        }

        public void Update()
        {
            Sandbox.OnWorldUpdate.Publish();
            Sandbox.OnCollisionDetectionRequested.Publish();
            Sandbox.OnWorldUpdateAfterCollisions.Publish();
            LoopCount++;
        }
    }
}