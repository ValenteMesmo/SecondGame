using NetworkStuff;
using System;

namespace ClientExemple
{
    class Program
    {
        static string IP = "192.168.0.7";
        static int port = 8001;

        static void Main(string[] args)
        {
            Console.Write("Digite o IP:");
            IP = Console.ReadLine();

            WhileException(() =>
            {
                Console.Write("Digite a porta:");
                port = int.Parse(Console.ReadLine());
            });

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

        private static void WhileException(Action action)
        {
            var exception = true;

            while (exception)
            {
                try
                {
                    action();
                    exception = false;
                }
                catch (Exception)
                {

                }
            }
        }

        private static void TryOnThesePorts(int listen, int write)
        {
            var client = Factory.CreateClient(listen, write);
            client.Listen(IP, port, messageReceived);

            while (true)
            {
                var msg = Console.ReadLine();
                client.SendMessage(msg);
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