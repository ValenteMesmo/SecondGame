using NetworkStuff.Udp;
using System.Collections.Generic;

namespace NetworkStuff.MessageHandlers
{
    public class BroadcastClientMessages : IHandleNetworkMessages
    {
        private readonly IEnumerable<Address> ConnectedClients;
        private readonly ISendNetworkMessages Writer;

        public BroadcastClientMessages(
            ISendNetworkMessages writer,
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
                    if (client.Ip != address.Ip 
                        && client.Port != address.Port)
                        Writer.Write("2" + actualMessage, client.Ip, client.Port);
                }
            }
        }
    }
}
