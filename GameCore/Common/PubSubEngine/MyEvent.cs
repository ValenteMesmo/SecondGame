using System;

namespace Common.PubSubEngine
{
    public class MyEvent<T>
    {
        private readonly Action<string, T, string> _pub;
        private readonly Action<string, Action<T>, string> _sub;

        internal MyEvent(
            Action<string, T, string> pub,
            Action<string, Action<T>, string> sub)
        {
            _pub = pub;
            _sub = sub;
            Name = Guid.NewGuid().ToString();
        }

        internal string Name { get; }

        public void Publish(T args, string filter = "")
        {
            _pub(Name, args, filter);
        }

        public void Subscribe(
            Action<T> callback,
            string filter = "")
        {
            _sub(Name, callback, filter);
        }
    }

    public class MyEvent
    {
        private readonly Action<string, string> _pub;
        private readonly Action<string, Action, string> _sub;

        internal MyEvent(
            Action<string, string> pub,
            Action<string, Action, string> sub)
        {
            _pub = pub;
            _sub = sub;
            Name = Guid.NewGuid().ToString();
        }

        internal string Name { get; }

        public void Publish(string filter = "")
        {
            _pub(Name, filter);
        }

        public void Subscribe(
            Action callback,
            string filter = "")
        {
            _sub(Name, callback, filter);
        }
    }
}