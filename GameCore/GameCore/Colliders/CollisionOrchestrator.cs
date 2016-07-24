//using GameCore.Commons;
//using System;
//using System.Collections.Generic;

//namespace GameCore
//{
//    public class CollisionOrchestrator
//    {
//        private readonly Func<Collider, Collider, bool> IsColliding;
//        private readonly IHandleCollision Handler;

//        public CollisionOrchestrator(IHandleCollision handler, Func<Collider,Collider, bool> isColliding)
//        {
//            Handler = handler;
//            IsColliding = isColliding;
//        }

//        public void OrchestrateCollisions(List<Collider> colliders)
//        {
//            colliders.ForEachCombination(DetectCollision);
//        }

//        private void DetectCollision(Collider first, Collider second)
//        {
//            if (IsColliding(first, second))
//            {
//                Handler.Handle(first, second);
//            }
//        }
//    }
//}
