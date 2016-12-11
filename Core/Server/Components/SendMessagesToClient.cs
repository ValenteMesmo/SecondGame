using Common;
using NetworkStuff.Udp;
using System;
using Common.GameComponents.PlayerComponents;
using NetworkStuff;
using System.Collections.Generic;
using System.Linq;

namespace Server.Components
{
    public class SendMessagesToClient : IDisposable
    {//fazer o esquema de guardar mensagens para rodar na thread do unity aqui... centralizado

        private readonly UdpMessageSender Sender;
        private readonly Sandbox Sandbox;
        private readonly List<Address> Addresses;

        public SendMessagesToClient(Sandbox sandbox, int port)
        {
            Sandbox = sandbox;
            Sender = new UdpMessageSender();
            Addresses = new List<Address>();
            Sandbox.PlayerUpdateAfterCollisions.Subscribe(OnPlayerUpdate);
            Sandbox.ServerEvents_PlayerConnected.Subscribe(PlayerConnected);
        }

        private void OnPlayerUpdate(Player player)
        {
            foreach (var address in Addresses)
            {
                var msg = string.Format(
                    "pp;{0};{1};{2}",
                    player.Body.X,
                    player.Body.Y,
                    player.Body.Name
                );
                Sender.Send(msg, address.Ip, address.Port);
            }
        }

        private void PlayerConnected(Address address)
        {
            if (Addresses.Any(f => f.Ip == address.Ip) == false)
            {
                Addresses.Add(address);
            }
        }

        public void Dispose()
        {
            Sender.Dispose();
        }
    }
}
