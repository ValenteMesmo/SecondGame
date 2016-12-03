using Common;
using NetworkStuff;
using NetworkStuff.Udp;
using System;
using System.Collections.Generic;

namespace Server.Components
{
    class SendMessagesToClient
    {//fazer o esquema de guardar mensagens para rodar na thread do unity aqui... centralizado
        internal class ListenMessagesFromClient : IDisposable
        {
            private readonly UdpMessageSender Sender;
            private readonly Sandbox Sandbox;

            public ListenMessagesFromClient(Sandbox sandbox, int port)
            {
                Sandbox = sandbox;
                Sender = new UdpMessageSender();                
            }
            
            public void Dispose()
            {
                Sender.Dispose();
            }
        }
    }
}
