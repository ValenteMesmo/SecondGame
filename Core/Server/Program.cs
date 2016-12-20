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
            Console.WriteLine(NetworkStuff.MessageHandlers.Common.NetworkHelper.GetLocalIPAddress());

            var world = new ServerWorld();
            world.Sandbox.PlayerUpdate.Subscribe(playerUpdate);
#if DEBUG
            world.Sandbox.Log.Subscribe(msg => Console.WriteLine(msg));
#endif
            while (true)
            {
                world.Update();
            }
        }

        private static void playerUpdate(Player obj)
        {
            Console.WriteLine(obj.Body.X + "," + obj.Body.Y);
        }
    }
}
