using NetworkStuff.MessageHandlers;
using NetworkStuff.Udp;
using System.Collections.Generic;

namespace NetworkStuff
{
    public class Host
    {
        public Host(            
            IListenToNetworkMessages listener,
            IWriteNetworkMessages writer)
        {
            Ip = listener.Ip;
            Port = listener.Port;

            var handlers = new List<IHandleNetworkMessages>();
            var clientsAddressKeeper = new List<Address>();

            handlers.Add(new VailidateMessageLength());
            handlers.Add(new ConnectionAttemptMessageHandler(writer, listener, clientsAddressKeeper));
            handlers.Add(new BroadcastClientMessages(writer, clientsAddressKeeper));

            var messageHandlersAggregator = new MessageHandlersAggregator(handlers);

            listener.Listen(messageHandlersAggregator.Handle);
        }

        public string Ip { get; private set; }
        public int Port { get; private set; }
    }
}