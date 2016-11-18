using NetworkStuff.Udp;

namespace NetworkStuff
{
    public class Factory
    {
        public static Host CreateHost(int port)
        {
            var listener = new UdpMessageListener(port);
            var writer = new UdpMessageSender();
                        
            var result = new Host(listener, writer);
            return result;
        }

        public static Client CreateClient(string serverAddress, int serverPort)
        {
            var listener = new UdpMessageListener(serverPort);
            var writer = new UdpMessageSender();

            var result = new Client(listener, writer, serverAddress, serverPort);
            return result;
        }
    }
}
