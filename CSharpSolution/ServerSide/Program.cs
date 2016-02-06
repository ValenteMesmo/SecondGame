using Core;
using System;

namespace ServerSide
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new GameServer();
            server.Start(Utils.GetLocalIPAddress().ToString(), 8001);
            Console.ReadKey();
            server.Dispose();
        }
    }
}
