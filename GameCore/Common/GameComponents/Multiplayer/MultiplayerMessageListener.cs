using System;
using NetworkStuff;
using NetworkStuff.Udp;
using Common.PubSubEngine;

namespace Common.GameComponents
{
    internal class MultiplayerMessageListener : IDisposable
    {
        private readonly UdpMessageListener Listener;
        private readonly Sandbox Sandbox;

        public MultiplayerMessageListener(Sandbox sandbox, int port)
        {
            Sandbox = sandbox;

            Listener = new UdpMessageListener(port);
            Listener.Listen(MessageReceived);
        }

        private void MessageReceived(string message, Address source)
        {
            if (message == "Connected")
                Sandbox.GuestJoined.Publish(source.Ip);
        }

        public void Dispose()
        {
            Listener.Dispose();
        }
    }
}
