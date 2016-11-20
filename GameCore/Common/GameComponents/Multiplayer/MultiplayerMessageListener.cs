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
        private string Ip;
        private int Port;

        public MultiplayerMessageListener(Sandbox sandbox, string ip, int port)
        {
            Ip = ip;
            Port = port;
            Sandbox = sandbox;

            Listener = new UdpMessageListener(Port);
            Listener.Listen(MessageReceived);
        }

        private void MessageReceived(string message, Address source)
        {
            Sandbox.NetwokMessageReceived.Publish(message, source.Ip);
        }

        public void Dispose()
        {
            Listener.Dispose();
        }
    }
}
