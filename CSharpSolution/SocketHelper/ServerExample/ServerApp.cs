using System;
namespace ConsoleApplication1{    class Program    {
        static void Main(string[] args)
        {
            var server = new ServerClass();
            server.Start(message => Console.WriteLine(message));

            while (true)
            {
                var msg = Console.ReadLine();
                server.SendMessage(msg);
            }
        }

    }
}

