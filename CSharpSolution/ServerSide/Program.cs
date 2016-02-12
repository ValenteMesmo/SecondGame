using System;

namespace ServerSide
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new GameServer(new World());
            server.Start(1337);
            Console.ReadKey();
            server.Dispose();
        }
    }
}