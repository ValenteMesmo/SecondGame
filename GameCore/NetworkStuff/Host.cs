using NetworkStuff.Udp;
using System.Collections.Generic;
using System;

namespace NetworkStuff
{
    public class Host
    {

        private Action<string, Address> MessageReceivedFromClient = (msg, address) => { };
        private readonly ISendNetworkMessages Writer;
        public readonly IList<Address> ClientsAddressKeeper;

        public Host(
            IListenToNetworkMessages listener,
            ISendNetworkMessages writer)
        {
            Writer = writer;
            ClientsAddressKeeper = new List<Address>();
            listener.Listen((msg, address) => MessageReceivedFromClient(msg, address));
        }

        public void Listen(Action<string, Address> messageReceivedFromClient)
        {
            MessageReceivedFromClient = messageReceivedFromClient;
        }

        public void SendMessage(string message)
        {
            foreach (var client in ClientsAddressKeeper)
            {
                Writer.Write(message, client.Ip, client.Port);
            }
        }

    }
}