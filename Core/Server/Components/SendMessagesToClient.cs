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
    {
        private readonly UdpMessageSender Sender;
        private readonly Sandbox Sandbox;
        private readonly List<string> Addresses;

        public SendMessagesToClient(Sandbox sandbox)
        {
            Sandbox = sandbox;
            Sender = new UdpMessageSender();
            Addresses = new List<string>();
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
                Sender.Send(msg, Addresses[i], 1338);
                //Sandbox.Log.Publish(Addresses[i].Ip +":"+ Addresses[i].Port);
            }
        }

        private void PlayerConnected(string address)
        {
            if (Addresses.Any(f => f == address))
                return;

            Addresses.Add(address);
        }

        public void Dispose()
        {
            Sender.Dispose();
        }
    }
}
