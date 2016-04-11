using System;
using System.Collections.Generic;

namespace NetworkStuff.Udp
{
    public class UpdMessageBroadcaster : IDisposable
    {
        private readonly IWriteNetworkMessages Writer;
        private readonly List<Endpoint> Listeners = new List<Endpoint>();

        public UpdMessageBroadcaster(IWriteNetworkMessages writer)
        {
            Writer = writer;
        }

        public void AddTarget(Endpoint endpoint)
        {
            Listeners.Add(endpoint);
        }

        public void Broadcast(string message)
        {
            foreach (var item in Listeners)
            {
                Writer.Write(
                    message,
                    item.Hostname,
                    item.Port);
            }
        }

        public void Dispose()
        {
            Writer.Dispose();
        }
    }

    public struct Endpoint
    {
        public readonly string Hostname;
        public readonly int Port;

        public Endpoint(string hostName, int port)
        {
            Hostname = hostName;
            Port = port;
        }
    }
}

