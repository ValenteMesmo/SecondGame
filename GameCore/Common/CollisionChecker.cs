using System.Collections.Generic;

namespace Common
{
    public class CollisionChecker
    {
        IList<Collider> Colliders = new List<Collider>();
        Sandbox Sandbox;
        public CollisionChecker(Sandbox sandbox)
        {
            Sandbox = sandbox;
            sandbox.Sub<Collider>(EventNames.COLLIDER_CREATED, OnColliderCreated);

            sandbox.Sub(EventNames.COLLISIONS_DETECTION_REQUESTED, DetectCollisions);
        }

        private void DetectCollisions()
        {
            Colliders.ForEachCombination(HandleSingleCollision);
        }

        private void HandleSingleCollision(
            Collider a,
            Collider b)
        {
            var rightPoint_a = a.X + a.Width;
            var rightPoint_b = b.X + b.Width;
            var topPoint_a = a.Y + a.Height;
            var topPoint_b = b.Y + b.Height;

            if (rightPoint_a < b.X
            || rightPoint_b < a.X
            || topPoint_a < b.Y
            || topPoint_b < a.Y)
                return;
            else
            {
                var top_b__bot_a__difference = topPoint_b - a.Y;
                var top_a__bot_b__difference = topPoint_a - b.Y;
                var right_a__left_b__difference = rightPoint_a - b.X;
                var right_b__left_a__difference = rightPoint_b - a.X;

                if (top_a__bot_b__difference < top_b__bot_a__difference
                    && top_a__bot_b__difference < right_a__left_b__difference
                    && top_a__bot_b__difference < right_b__left_a__difference)
                {
                    Sandbox.Pub(EventNames.COLLISION_FROM_BELOW, a, b.Name);
                    Sandbox.Pub(EventNames.COLLISION_FROM_ABOVE, b, a.Name);
                    return;
                }

                if (top_b__bot_a__difference < top_a__bot_b__difference
                    && top_b__bot_a__difference < right_a__left_b__difference
                    && top_b__bot_a__difference < right_b__left_a__difference)
                {
                    Sandbox.Pub(EventNames.COLLISION_FROM_BELOW, b, a.Name);
                    Sandbox.Pub(EventNames.COLLISION_FROM_ABOVE, a, b.Name);
                    return;
                }

                if (right_a__left_b__difference < right_b__left_a__difference
                    && right_a__left_b__difference < top_a__bot_b__difference
                    && right_a__left_b__difference < top_b__bot_a__difference)
                {
                    Sandbox.Pub(EventNames.COLLISION_FROM_THE_LEFT, a, b.Name);
                    Sandbox.Pub(EventNames.COLLISION_FROM_THE_RIGHT, b, a.Name);
                    return;
                }

                if (right_b__left_a__difference < right_a__left_b__difference
                    && right_b__left_a__difference < top_a__bot_b__difference
                    && right_b__left_a__difference < top_b__bot_a__difference)
                {
                    Sandbox.Pub(EventNames.COLLISION_FROM_THE_LEFT, b, a.Name);
                    Sandbox.Pub(EventNames.COLLISION_FROM_THE_RIGHT, a, b.Name);
                    return;
                }
            }
        }

        private void OnColliderCreated(Collider collider)
        {
            Colliders.Add(collider);
        }
    }
}
