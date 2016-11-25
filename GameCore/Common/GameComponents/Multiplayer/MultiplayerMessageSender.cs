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
            Sandbox.HostPositionUpdated.Subscribe(SendHostPositionToHost, ip);
            Sandbox.YouEnteredThePortal.Subscribe(EnteredMultiplayePortal);
        }

        private void EnteredMultiplayePortal(MultiplayerPortal obj)
        {
            Sender.Send("Connected", obj.Ip, 1337);
        }

        private void SendHostPositionToHost(Collider obj)
        {
            Sender.Send(
                string.Format(
                    "coord;{0};{1}",
                    obj.X,
                    obj.Y),
                Ip,
                Port);
        }

        public void Dispose()
        {
            Sender.Dispose();
        }
    }
}
