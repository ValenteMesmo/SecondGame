using System;

namespace ServerSide
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new GameServer();
            server.Start(1337);
            Console.ReadKey();
            server.Dispose();
        }
    }
}