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
        public Action<Collider> OnCollision { get; set; }
    }

    public static class XXX
    {
        public static void ForEachCombination<T>(
            this IList<T> items,
            Action<T, T> callback)
        {
            for (int i = 0; i < items.Count - 1; i++)
            {
                for (int j = items.Count -1; j > i; j--)
                {
                    callback(items[i], items[j]);
                }
            }
        }

        public static void HandleCollisions(this IList<Collider> colliders)
        {
            colliders.ForEachCombination(HandleSingleCollision);
        }

        private static void HandleSingleCollision(Collider a, Collider b)
        {
            if (a.X + a.Width < b.X
            || b.X + b.Width < a.X
            || a.Y + a.Height < b.Y
            || b.Y + b.Height < a.Y)
                return;
            else
            {
                a.OnCollision(b);
                b.OnCollision(a);
            }
        }
    }
}