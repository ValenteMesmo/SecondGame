using System.Diagnostics;
using System.Threading;

namespace NetworkStuff.Tests
{
    public class AsyncAssert
    {
        private static bool Waiting;

        public static void Wait(int timeout = 100)
        {
            var stopwatch = new Stopwatch();

            Waiting = true;
            stopwatch.Start();

            while (
                stopwatch.ElapsedMilliseconds < timeout
                && Waiting)
            {
                Thread.Sleep(1);
            }

            stopwatch.Stop();
            Waiting = false;
        }

        public static void Done()
        {
            Waiting = false;
        }
    }
}
