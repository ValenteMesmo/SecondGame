using NetworkStuff;
using System;

namespace HostExemple
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = Factory.CreateHost(20010, 20011);


            Console.ReadKey();
        }
    }
}
