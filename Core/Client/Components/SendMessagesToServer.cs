﻿using Common;
using NetworkStuff.Udp;
using System;
using Common.GameComponents.PlayerComponents;
using System.Globalization;

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
                player.Body.X.ToString(CultureInfo.InvariantCulture),
                player.Body.Y.ToString(CultureInfo.InvariantCulture),
                player.Body.Name
            );

            Sender.Send(msg, Ip, Port);
            //Sandbox.Log.Publish(msg);
            //Sandbox.Log.Publish(Ip +":"+ Port);
        }

        public void Dispose()
        {
            Sender.Dispose();
        }
    }
}
