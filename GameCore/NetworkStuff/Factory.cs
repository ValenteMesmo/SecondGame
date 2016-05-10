using NetworkStuff.Udp;
using System;

namespace NetworkStuff
{
    public class Factory
    {
        public static Host CreateHost(int listeningPort, int writingPort)
        {
            var listener = new UdpMessageListener(listeningPort);
            var writer = new UdpMessageWriter();
            Console.WriteLine(string.Format("Hosting on {0}:{1}", listener.Ip, listener.Port));
            var result = new Host(listener, writer);
            return result;
        }

        public static Client CreateClient(int listeningPort, int writingPort)
        {
            var listener = new UdpMessageListener(listeningPort);
            var writer = new UdpMessageWriter();

            var result = new Client(listener, writer);
            return result;
        }
    }
}
