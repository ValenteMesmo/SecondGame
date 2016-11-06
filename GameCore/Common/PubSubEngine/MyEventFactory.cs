using System;
using System.Collections.Generic;

namespace Common.PubSubEngine
{
    internal class MyEventFactory
    {
        private readonly Dictionary<string, List<Action<object>>> Callbacks =
            new Dictionary<string, List<Action<object>>>();

        private void Pub<T>(string eventName, T args, string channel = "")
        {
            eventName += channel;
            if (Callbacks.ContainsKey(eventName))
                foreach (var item in Callbacks[eventName])
                {
                    item(args);
                }
        }

        private void Pub(string eventName, string channel = "")
        {
            eventName += channel;
            if (Callbacks.ContainsKey(eventName))
                foreach (var item in Callbacks[eventName])
                {
                    item(null);
                }
        }

        private void Sub<T>(string eventName, Action<T> callback, string channel = "")
        {
            eventName += channel;
            if (Callbacks.ContainsKey(eventName) == false)
                Callbacks.Add(eventName, new List<Action<object>>());

            Callbacks[eventName].Add(new Action<object>(o => callback((T)o)));
        }

        private void Sub(string eventName, Action callback, string channel = "")
        {
            eventName += channel;
            if (Callbacks.ContainsKey(eventName) == false)
                Callbacks.Add(eventName, new List<Action<object>>());

            Callbacks[eventName].Add(new Action<object>(o => callback()));
        }

        internal MyEvent<T> Create<T>()
        {
            return new MyEvent<T>(Pub, Sub);
        }

        internal MyEvent Create()
        {
            return new MyEvent(Pub, Sub);
        }
    }
}