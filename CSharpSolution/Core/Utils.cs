using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Core
{
    public class Utils
    {
        static Utils()
        {
            //TODO: remove this...  may not work well with unity
            Trace.Listeners.Add(new TextWriterTraceListener("MyTextFile.log"));
        }

        public static Thread RunInBackground(Action action)
        {

            var thread = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                action();
            });
            thread.Start();
            return thread;
        }

        public static void Log(string msg)
        {
            Trace.Write(msg);
        }

        public static IPAddress GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }
    }

}
