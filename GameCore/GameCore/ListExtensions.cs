using System;
using System.Collections.Generic;

namespace GameCore
{
    public static class ListExtensions
    {
        public static void ForEachCombination<T>(this List<T> list, Action<T, T> action)
        {
            if (list == null)
                throw new ArgumentNullException(
                    "list",
                    "Sorry! But I cannot find combinations if the list is NULL!");

            if (action == null)
                throw new ArgumentNullException(
                    "action",
                    "Sorry! But I need to call this action for every combination. It cannot be NULL!");

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