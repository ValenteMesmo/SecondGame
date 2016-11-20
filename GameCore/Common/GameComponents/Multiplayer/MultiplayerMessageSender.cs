using System;
using NetworkStuff.Udp;
using Common.PubSubEngine;

namespace Common.GameComponents
{
    internal class MultiplayerMessageSender : IDisposable
    {
        private readonly UdpMessageSender Sender;
        private readonly Sandbox Sandbox;
        private string Ip;
        private int Port;

        public MultiplayerMessageSender(Sandbox sandbox, string ip, int port)
        {
            Ip = ip;
            Port = port;
            Sandbox = sandbox;

            Sender = new UdpMessageSender();

            Sandbox.SendNetwokMessage.Subscribe(OnSendMessageRequested, Ip);
        }

        private void OnSendMessageRequested(string message)
        {
            Sender.Send(message, Ip, Port);
        }        

        public void Dispose()
        {
            Sender.Dispose();
        }
    }
}
