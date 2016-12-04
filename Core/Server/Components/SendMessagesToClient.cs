using Common;
using NetworkStuff.Udp;
using System;
using Common.GameComponents.PlayerComponents;
using NetworkStuff;
using System.Collections.Generic;

namespace Server.Components
{
    class SendMessagesToClient
    {//fazer o esquema de guardar mensagens para rodar na thread do unity aqui... centralizado
        internal class ListenMessagesFromClient : IDisposable
        {
            private readonly UdpMessageSender Sender;
            private readonly Sandbox Sandbox;
            private readonly Dictionary<string,>

            public ListenMessagesFromClient(Sandbox sandbox, int port)
            {
                Sandbox = sandbox;
                Sender = new UdpMessageSender();
                Sandbox.PlayerUpdateAfterCollisions.Subscribe(OnPlayerUpdate);
                Sandbox.PlayerConnected.Subscribe(PlayerConnected);
            }

            private void PlayerConnected(Address playerAddress)
            {
                
            }

            private void OnPlayerUpdate(Player player)
            {
                Sender.Send();
            }

            public void Dispose()
            {
                Sender.Dispose();
            }
        }
    }
}
