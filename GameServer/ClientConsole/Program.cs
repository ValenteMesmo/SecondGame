using NetworkStuff.Udp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var writer = new UdpMessageWriter(20005);
            new UdpMessageListener(20006).Listen(msg =>
            {
                Console.WriteLine("Server: " + msg);
            });
            while (true)
            {
                writer.Write(Console.ReadLine(),"localhost", 20001);
            }

        }
    }
}
