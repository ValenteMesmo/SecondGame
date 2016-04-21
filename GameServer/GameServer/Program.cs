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
            var writer = new UdpMessageWriter(20001);

            var broadcaster = new UpdMessageBroadcaster(writer);
            //broadcaster.AddTarget(
            //    new Endpoint("localhost", 20006));

            new UdpMessageListener(20000).Listen((msg, endpoint) =>
            {
                Console.WriteLine("From client: " + msg);
                broadcaster.AddTarget(endpoint);
                broadcaster.Broadcast(msg);
            });

            Console.ReadKey();
        }
    }
}
