using NetworkStuff.MessageHandlers;
using NetworkStuff.MessageHandlers.Common;
using NetworkStuff.Udp;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkStuff
{
    public class Client
    {
        private readonly IWriteNetworkMessages Writer;
        private readonly IListenToNetworkMessages Listener;
        private Address HostAddress;
        private bool Connected;
        private Action<string, Address> MessageReceivedFromHost;

        public Client(
            IListenToNetworkMessages listener,
            IWriteNetworkMessages writer)
        {
            Writer = writer;
            Listener = listener;

            var handlers = new List<IHandleNetworkMessages>();

            handlers.Add(new VailidateMessageLength());
            handlers.Add(new ConnectionAcceptedMessageHandler(WhenHostAcknowledgesYourListeningPort));
            handlers.Add(new ActualMessageReceived(WhenMessageReceivedFromHost));

            var messageHandlersAggregator = new MessageHandlersAggregator(handlers);

            listener.Listen(messageHandlersAggregator.Handle);
        }

        private void WhenMessageReceivedFromHost(string message, Address ip)
        {
            MessageReceivedFromHost(message, ip);
        }

        private void WhenHostAcknowledgesYourListeningPort(Address address)
        {
            //TODO: Findout why the parameter received here got the wrong port!
            //Thats the reason for this flag! V
            Connected = true;
        }

        public void SendMessage(string message)
        {
            if (Connected == false)
                throw new Exception("First you need to 'InformYourListeningPortToHost'");

            Writer.Write("2"+message, HostAddress.Ip, HostAddress.Port);
        }

        public void InformYourListeningPortToHost(
            string hostIp, 
            int hostPort, 
            Action<string, Address> messageReceived)
        {
            HostAddress = new Address(hostIp, hostPort);
            var msg = new StringBuilder();

            msg.Append(MessageConstants.CONNECTION_REQUEST_PREFIX);
            msg.Append(Listener.Ip);
            msg.Append(':');
            msg.Append(Listener.Port);

            Writer.Write(msg.ToString(), hostIp, hostPort);

            MessageReceivedFromHost = messageReceived;
        }
    }
}