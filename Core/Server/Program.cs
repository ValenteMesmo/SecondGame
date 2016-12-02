using Common;
using System.Threading;

namespace Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var world = new ServerWorld();

            while (true)
            {
                world.Update();
                Thread.Sleep(1);
            }
        }
    }
}
