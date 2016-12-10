using Common;
using NetworkStuff.Udp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.GameComponents.PlayerComponents;

namespace Client.Components
{
    class SendMessagesToServer : IDisposable
    {
        private readonly UdpMessageSender Sender;
        private readonly Sandbox Sandbox;
        private readonly int Port;
        private readonly string Ip;

        public SendMessagesToServer(Sandbox sandbox, string ip, int port)
        {
            Ip = ip;
            Port = port;
            Sandbox = sandbox;
            Sender = new UdpMessageSender();
            Sandbox.PlayerUpdateAfterCollisions.Subscribe(PlayerUpdated);
        }

        private void PlayerUpdated(Player player)
        {
            var msg = string.Format(
                "pp;{0};{1};{2}",
                player.Body.X,
                player.Body.Y,
                player.Body.Name
            );

            Sender.Send(msg, Ip, Port);
        }

        public void Dispose()
        {
            Sender.Dispose();
        }
    }
}
