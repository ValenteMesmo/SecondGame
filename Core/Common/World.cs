using Common.GameComponents.Factories;
using System;
using System.Collections.Generic;

namespace Common
{
    public abstract class World : IDisposable
    {
        public readonly Sandbox Sandbox;
        protected readonly List<IDisposable> Disposables;
        public int LoopCount { get; private set; }

        public World()
        {
            Disposables = new List<IDisposable>();
            Sandbox = new Sandbox();
            new CollisionChecker(Sandbox);
            new PlayerFactory(Sandbox);
            new GroundFactory(Sandbox);
            new MonsterFactory(Sandbox);
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
            if (LoopCount == 0)
            {
                Initialize();
            }

            Sandbox.OnWorldUpdate.Publish();
            Sandbox.OnCollisionDetectionRequested.Publish();
            Sandbox.OnWorldUpdateAfterCollisions.Publish();
            LoopCount++;
        }

        protected virtual void Initialize()
        {
            for (int i = 0; i < 10; i++)
            {
                Sandbox.GroundAdded.Publish(new Position(i * 3, 0));
            }

            Sandbox.MonsterAdded.Publish(new Position(6, 3));
        }
    }
}