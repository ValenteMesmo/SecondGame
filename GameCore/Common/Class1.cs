using System;
using System.Collections.Generic;

namespace Common
{
    public interface IGameObject
    {
        float X { get; }
        float Y { get; }
        float Width { get; }
        float Height { get; }
    }

    public class Collider: IGameObject
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public Action<IGameObject> OnCollision = other => { };
        public Action<IGameObject> OnTopCollision = other => { };
        public Action<IGameObject> OnBotCollision = other => { };
        public Action<IGameObject> OnLeftCollision = other => { };
        public Action<IGameObject> OnRightCollision = other => { };
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

        public static void HandleCollisions(
            this IList<Collider> colliders)
        {
            colliders.ForEachCombination(
                HandleSingleCollision);
        }

        private static void HandleSingleCollision(
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
                    a.OnTopCollision(b);
                    a.OnCollision(b);
                    b.OnBotCollision(a);
                    b.OnCollision(a);
                    return;
                }

                if (top_b__bot_a__difference < top_a__bot_b__difference
                    && top_b__bot_a__difference < right_a__left_b__difference
                    && top_b__bot_a__difference < right_b__left_a__difference)
                {
                    a.OnBotCollision(b);
                    a.OnCollision(b);
                    b.OnTopCollision(a);
                    b.OnCollision(a);
                    return;
                }

                if (right_a__left_b__difference < right_b__left_a__difference
                    && right_a__left_b__difference < top_a__bot_b__difference
                    && right_a__left_b__difference < top_b__bot_a__difference)
                {
                    a.OnRightCollision(b);
                    a.OnCollision(b);
                    b.OnLeftCollision(a);
                    b.OnCollision(a);
                    return;
                }

                if (right_b__left_a__difference < right_a__left_b__difference
                    && right_b__left_a__difference < top_a__bot_b__difference
                    && right_b__left_a__difference < top_b__bot_a__difference)
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