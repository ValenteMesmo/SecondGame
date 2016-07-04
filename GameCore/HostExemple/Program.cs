using NetworkStuff;
using System;

namespace HostExemple
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = Factory.CreateHost(20010, 20011);

            host.SetMessageReceivedHandler(messageReceived);

            while (true)
            {
                var msg = Console.ReadLine();
                host.SendMessage(msg);
            }
        }

        private static void messageReceived(string msg, Address address)
        {
            Console.WriteLine(string.Format("{0}:{1} => {2}", address.Ip, address.Port, msg));
        }
    }
}
