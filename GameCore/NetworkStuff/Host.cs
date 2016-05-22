using NetworkStuff.MessageHandlers;
using NetworkStuff.MessageHandlers.Common;
using NetworkStuff.Udp;
using System.Collections.Generic;
using System;

namespace NetworkStuff
{
    public class Host
    {
        public string Ip { get; private set; }
        public int Port { get; private set; }

        private Action<string, Address> MessageReceivedFromClient = (msg, address) => { };
        public void SetMessageReceivedHandler(Action<string, Address> messageReceivedFromClient)
        {
            MessageReceivedFromClient = messageReceivedFromClient;
        }


        readonly IWriteNetworkMessages Writer;
        readonly IList<Address> ClientsAddressKeeper;

        public Host(
            IListenToNetworkMessages listener,
            IWriteNetworkMessages writer)
        {
            Writer = writer;
            Ip = listener.Ip;
            Port = listener.Port;

            var handlers = new List<IHandleNetworkMessages>();
            ClientsAddressKeeper = new List<Address>();

            handlers.Add(new VailidateMessageLength());
            handlers.Add(new ConnectionAttemptMessageHandler(writer, listener, ClientsAddressKeeper));
            handlers.Add(new BroadcastClientMessages(writer, ClientsAddressKeeper));
            handlers.Add(new ActualMessageReceived(WhenMessageReceivedFromHost));

            var messageHandlersAggregator = new MessageHandlersAggregator(handlers);

            listener.Listen(messageHandlersAggregator.Handle);
        }

        private void WhenMessageReceivedFromHost(string message, Address address)
        {
            MessageReceivedFromClient(message, address);
        }

        public void SendMessage(string message)
        {
            foreach (var client in ClientsAddressKeeper)
            {
                //TODO: ops! this enconding should be centralized
                Writer.Write("2" + message, client.Ip, client.Port);
            }
        }

    }
}