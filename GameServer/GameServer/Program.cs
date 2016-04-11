using NetworkStuff.Udp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var writer = new UdpMessageWriter(20002);

            var broadcaster = new UpdMessageBroadcaster(writer);
            broadcaster.AddTarget(
                new Endpoint("localhost", 20006));

            new UdpMessageListener(20001).Listen(msg =>
            {
                Console.WriteLine("From client: "+msg);
                broadcaster.Broadcast(msg);
            });

            Console.ReadKey();
        }
    }
}
