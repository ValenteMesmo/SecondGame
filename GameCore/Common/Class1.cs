using System;
using System.Collections.Generic;

namespace Common
{
    public class Collider
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public Action<Collider> OnCollision = other => { };
        public Action<Collider> OnTopCollision = other => { };
        public Action<Collider> OnBotCollision = other => { };
        public Action<Collider> OnLeftCollision = other => { };
        public Action<Collider> OnRightCollision = other => { };
    }

    public static class XXX
    {
        public static void ForEachCombination<T>(
            this IList<T> items,
            Action<T, T> callback)
        {
            for (int i = 0; i < items.Count - 1; i++)
            {
                for (int j = items.Count - 1; j > i; j--)
                {
                    callback(items[i], items[j]);
                }
            }
        }

        public static void HandleCollisions(this IList<Collider> colliders)
        {
            colliders.ForEachCombination(
                HandleSingleCollision);
        }

        private static void HandleSingleCollision(Collider a, Collider b)
        {
            var a_rightPoint = a.X + a.Width;
            var b_rightPoint = b.X + b.Width;
            var a_topPoint = a.Y + a.Height;
            var b_topPoint = b.Y + b.Height;

            if (a_rightPoint < b.X
            || b_rightPoint < a.X
            || a_topPoint < b.Y
            || b_topPoint < a.Y)
                return;
            else
            {
                var bot_collision = b_topPoint - a.Y;
                var top_collision = a_topPoint - b.Y;
                var left_collision = a_rightPoint - b.X;
                var right_collision = b_rightPoint - a.X;

                if (top_collision < bot_collision
                    && top_collision < left_collision
                    && top_collision < right_collision)
                {
                    a.OnTopCollision(b);
                    a.OnCollision(b);
                    b.OnBotCollision(a);
                    b.OnCollision(a);
                    return;
                }

                if (bot_collision < top_collision
                    && bot_collision < left_collision
                    && bot_collision < right_collision)
                {
                    a.OnBotCollision(b);
                    a.OnCollision(b);
                    b.OnTopCollision(a);
                    b.OnCollision(a);
                    return;
                }

                if (left_collision < right_collision
                    && left_collision < top_collision
                    && left_collision < bot_collision)
                {
                    a.OnRightCollision(b);
                    a.OnCollision(b);
                    b.OnLeftCollision(a);
                    b.OnCollision(a);
                    return;
                }

                if (right_collision < left_collision
                    && right_collision < top_collision
                    && right_collision < bot_collision)
                {
                    a.OnLeftCollision(b);
                    a.OnCollision(b);
                    b.OnRightCollision(a);
                    b.OnCollision(a);
                    return;
                }
            }
        }
    }
}