using System;
using System.Collections.Generic;

namespace GameCore
{
    public static class ListExtensions
    {
        public static void ForEachCombinations<T>(this List<T> list, Action<T, T> action)
        {
            for (int i = 0; i < list.Count -1; i++)
            {
                for (int j = list.Count -1; j > i; j--)
                {
                    action(list[i], list[j]);
                }
            }
        }
    }
}