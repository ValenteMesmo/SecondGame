using System;
using System.Threading;

namespace Common.Helpers
{
    public class Task : IDisposable
    {
        private readonly Thread thread;

        public Task(Action action)
        {
            var operation = new ThreadStart(action);
            thread = new Thread(operation, 1024 * 1024);
            thread.Start();            
        }

        public void Dispose()
        {
            thread.Abort();
        }
    }
}
