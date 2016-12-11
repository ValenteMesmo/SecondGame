using Common;
using NetworkStuff.Udp;
using System;
using Common.GameComponents.PlayerComponents;
using NetworkStuff;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace Server.Components
{
    public class SendMessagesToClient : IDisposable
    {//fazer o esquema de guardar mensagens para rodar na thread do unity aqui... centralizado

        private readonly UdpMessageSender Sender;
        private readonly Sandbox Sandbox;
        private readonly List<Address> Addresses;

        public SendMessagesToClient(Sandbox sandbox)
        {
            Sandbox = sandbox;
            Sender = new UdpMessageSender();
            Addresses = new List<Address>();
            Sandbox.PlayerUpdateAfterCollisions.Subscribe(OnPlayerUpdate);
            Sandbox.ServerEvents_PlayerConnected.Subscribe(PlayerConnected);
        }

        private void OnPlayerUpdate(Player player)
        {
            for (int i = 0; i < Addresses.Count; i++)
            {            
                var msg = string.Format(
                    "pp;{0};{1};{2}",
                    player.Body.X.ToString(CultureInfo.InvariantCulture),
                    player.Body.Y.ToString(CultureInfo.InvariantCulture),
                    player.Body.Name
                );

                //Console.WriteLine(msg);
                Sender.Send(msg, Addresses[i].Ip, 1338);
                //Sandbox.Log.Publish(Addresses[i].Ip +":"+ Addresses[i].Port);
            }
        }

        private void PlayerConnected(Address address)
        {
            if (Addresses.Any(f => f.Ip == address.Ip && address.Port == f.Port))
                return;

            Addresses.Add(address);
        }

        public void Dispose()
        {
            Sender.Dispose();
        }
    }
}
