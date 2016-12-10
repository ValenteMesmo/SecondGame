using Common;
using System.Threading;
using Common.GameComponents.PlayerComponents;
using System;

namespace Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var world = new ServerWorld();

            world.Sandbox.PlayerUpdate.Subscribe(playerUpdate);

            while (true)
            {
                world.Update();
                Thread.Sleep(1);
            }
        }

        private static void playerUpdate(Player obj)
        {
            Console.WriteLine(obj.Body.X + "," + obj.Body.Y);
        }
    }
}
