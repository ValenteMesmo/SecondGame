using NetworkStuff;
using System;

namespace ClientExemple
{
    class Program
    {
        static void Main(string[] args)
        {
            var listen = 20012;
            var write = 20013;
            while (true)
            {
                try
                {
                    TryOnThesePorts(listen++, write++);
                }
                catch (Exception)
                {
                }
            }
        }

        private static void TryOnThesePorts(int listen, int write)
        {
            var client = Factory.CreateClient(listen, write);
            client.InformYourListeningPortToHost("localhost", 20010, messageReceived);

            while (true)
            {
                client.SendMessage(Console.ReadLine());
            }
        }

        private static void messageReceived(string arg1, Address arg2)
        {
            Console.WriteLine(
                string.Format("{0}:{1} => {2}", arg2.Ip, arg2.Port, arg1)
                );
        }
    }
}
