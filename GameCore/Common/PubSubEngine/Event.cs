using System;
using System.Linq;
using System.Collections.Generic;

namespace Common.PubSubEngine
{
    public class Event<T>
    {
        private readonly Dictionary<string, List<Action<T>>> Callbacks =
            new Dictionary<string, List<Action<T>>>();

        public void Subscribe(Action<T> callback, string context = "")
        {
            var key = GetKey(callback, context);

            if (Callbacks.ContainsKey(key) == false)
            {
                Callbacks[key] = new List<Action<T>>();
            }

            if (Callbacks[key].Contains(callback))
                return;

            Callbacks[key].Add(callback);
        }

        public void Unsubscribe(Action<T> callback, string context = "")
        {
            var key = GetKey(callback, context);

            if (Callbacks.ContainsKey(key) && Callbacks[key].Contains(callback))
                Callbacks[key].Remove(callback);
        }

        public void Publish(T arg, string context = "")
        {
            var partialKey = context + ":";
            var callbacksToExcecute = Callbacks
                .Where(f => f.Key.StartsWith(partialKey))
                .SelectMany(f => f.Value);

            foreach (var callback in callbacksToExcecute)
            {
                callback(arg);
            }
        }

        private string GetKey(Action<T> callback, string context)
        {
            return string.Format("{0}:{1}", context, callback.GetHashCode());
        }
    }

    public class Event
    {
        private readonly Dictionary<string, List<Action>> Callbacks =
            new Dictionary<string, List<Action>>();

        public void Subscribe(Action callback, string context = "")
        {
            var key = GetKey(callback, context);

            if (Callbacks.ContainsKey(key) == false)
            {
                Callbacks[key] = new List<Action>();
            }

            if (Callbacks[key].Contains(callback))
                return;

            Callbacks[key].Add(callback);
        }

        public void Unsubscribe(Action callback, string context = "")
        {
            var key = GetKey(callback, context);

            if (Callbacks.ContainsKey(key) && Callbacks[key].Contains(callback))
                Callbacks[key].Remove(callback);
        }

        public void Publish(string context = "")
        {
            var partialKey = context + ":";
            var callbacksToExcecute = Callbacks
                .Where(f => f.Key.StartsWith(partialKey))
                .SelectMany(f => f.Value);

            foreach (var callback in callbacksToExcecute)
            {
                callback();
            }
        }

        private string GetKey(Action callback, string context)
        {
            return string.Format("{0}:{1}", context, callback.GetHashCode());
        }
    }
}