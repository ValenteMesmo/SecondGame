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

        double time;
        const double deltaTime = 0.01;
        double currentTime;
        double accumulator;

        public World()
        {
            Sandbox = new Sandbox();
            Disposables = new List<IDisposable>();
            new CollisionChecker(Sandbox);
            new GroundFactory(Sandbox);
            new MonsterFactory(Sandbox);
        }

        public void Update()
        {
            if (LoopCount == 0)
                Initialize();

            var newTime = GetTimeInSeconds();
            double frameTime = newTime - currentTime;
            if (frameTime > 0.25)
                frameTime = 0.25;

            currentTime = newTime;
            accumulator += frameTime;

            while (accumulator >= deltaTime)
            {
                Sandbox.OnWorldUpdate.Publish();
                Sandbox.OnCollisionDetectionRequested.Publish();
                Sandbox.OnWorldUpdateAfterCollisions.Publish();
                LoopCount++;
                time += deltaTime;
                accumulator -= deltaTime;
            }

            double alpha = accumulator / deltaTime;
            //State state = currentState * alpha + previousState * (1.0 - alpha);

            //render(state);
        }

        public void Dispose()
        {
            foreach (var item in Disposables)
            {
                item.Dispose();
            }
        }

        protected virtual void Initialize()
        {
            for (int i = 0; i < 10; i++)
            {
                Sandbox.GroundAdded.Publish(new Position(i * 3, 0));
            }

            Sandbox.MonsterAdded.Publish(new Position(6, 3));

            time = 0.0;
            currentTime = GetTimeInSeconds();
            accumulator = 0.0;
        }

        private double GetTimeInSeconds()
        {
            return (DateTime.Now - DateTime.MinValue).TotalSeconds;
        }
    }
}
