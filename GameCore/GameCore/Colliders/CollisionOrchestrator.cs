using System.Collections.Generic;

namespace GameCore
{
    public class CollisionOrchestrator
    {
        private readonly CollisionDetector Detector;
        private readonly IHandleCollision Handler;

        public CollisionOrchestrator(IHandleCollision handler, CollisionDetector detector)
        {
            Handler = handler;
            Detector = detector;
        }

        public void OrchestrateCollisions(List<Collider> colliders)
        {
            colliders.ForEachCombination(DetectCollision);
        }

        private void DetectCollision(Collider first, Collider second)
        {
            if (Detector.IsColliding(first, second))
            {
                Handler.Handle(first, second);
            }
        }
    }
}
