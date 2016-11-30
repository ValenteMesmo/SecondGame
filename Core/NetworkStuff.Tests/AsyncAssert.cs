using Microsoft.VisualStudio.TestTools.UnitTesting;
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

            while (Waiting)
            {
                if (stopwatch.ElapsedMilliseconds > timeout)
                {
                    throw new System.Exception(
                       string.Format("The AsyncAssert.Done was not called before the {0} Timeout.", timeout));
                }

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
