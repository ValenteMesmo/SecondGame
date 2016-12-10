using Common;
using NetworkStuff.Udp;
using System;
using Common.GameComponents.PlayerComponents;
using NetworkStuff;
using System.Collections.Generic;

namespace Server.Components
{
    public class SendMessagesToClient : IDisposable
    {//fazer o esquema de guardar mensagens para rodar na thread do unity aqui... centralizado

        private readonly UdpMessageSender Sender;
        private readonly Sandbox Sandbox;
        //private readonly Dictionary<string,.>

        public SendMessagesToClient(Sandbox sandbox, int port)
        {
            Sandbox = sandbox;
            Sender = new UdpMessageSender();
            //Sandbox.PlayerUpdateAfterCollisions.Subscribe(OnPlayerUpdate);
            //Sandbox.ServerEvents_PlayerConnected.Subscribe(PlayerConnected);
        }

        //private void OnPlayerUpdate(Player player)
        //{
        //    //Sender.Send();
        //}

        public void Dispose()
        {
            Sender.Dispose();
        }
    }
}
