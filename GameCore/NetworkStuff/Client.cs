using NetworkStuff.Udp;
using System;

namespace NetworkStuff
{
    public class Client
    {
        private readonly ISendNetworkMessages Writer;
        private readonly IListenToNetworkMessages Listener;
        private Action<string, Address> MessageReceivedFromHost;
        private readonly string ServerIp;
        private readonly int ServerPort;

        public Client(
            IListenToNetworkMessages listener,
            ISendNetworkMessages writer,
            string serverIp,
            int serverPort)
        {
            Writer = writer;
            Listener = listener;
            ServerIp = serverIp;
            ServerPort = serverPort;
        }
        
        public void SendMessage(string message)
        {
            Writer.Write("2" + message, ServerIp, ServerPort);
        }

        public void Listen(
            Action<string, Address> onMessageReceived)
        {
            MessageReceivedFromHost = onMessageReceived;
        }
    }
}