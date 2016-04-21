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
            new UdpMessageListener(20010).Listen((msg, endpoint) =>
            {
                Console.WriteLine("Server: " + msg);
            });

            var writer = new UdpMessageWriter(20011);
            while (true)
            {
                writer.Write(Console.ReadLine(), "localhost", 20000);
            }
        }
    }
}