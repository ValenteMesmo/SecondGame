using System;
using System.Linq;
using System.Collections.Generic;

namespace NetworkStuff.Udp
{
    public class UpdMessageBroadcaster : IDisposable
    {
        private readonly IWriteNetworkMessages Writer;
        private readonly List<Address> Listeners = new List<Address>();

        public UpdMessageBroadcaster(IWriteNetworkMessages writer)
        {
            Writer = writer;
        }

        public void AddTarget(Address endpoint)
        {
            if (Listeners.Any(f =>
                 f.Ip == endpoint.Ip
                 && f.Port == endpoint.Port))
                return;

            Listeners.Add(endpoint);
        }

        public void Broadcast(string message)
        {
            foreach (var item in Listeners)
            {
                Writer.Write(
                    message,
                    item.Ip,
                    item.Port);
            }
        }

        public void Dispose()
        {
            Writer.Dispose();
        }
    }
}

