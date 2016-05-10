using NetworkStuff.Udp;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NetworkStuff.MessageHandlers
{
    public class BroadcastClientMessages : IHandleNetworkMessages
    {
        private readonly IEnumerable<Address> ConnectedClients;
        private readonly IWriteNetworkMessages Writer;

        public BroadcastClientMessages(
            IWriteNetworkMessages writer, 
            IEnumerable<Address> connectedClients)
        {
            ConnectedClients = connectedClients;
            Writer = writer;
        }

        public void Handle(string message, Address address)
        {
            if (message[0] == '2')
            {
                var actualMessage = message.Substring(1); 

                foreach (var client in ConnectedClients)
                {
                    Writer.Write("2" + actualMessage, client.Ip, client.Port);   
                }                
            }
        }
    }
}
