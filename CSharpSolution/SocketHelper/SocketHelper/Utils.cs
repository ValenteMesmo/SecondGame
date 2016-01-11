using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SocketHelper
{
    class Utils
    {
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
            try
            {
                using (FileStream fs = new FileStream("logs.txt", FileMode.OpenOrCreate, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(msg);
                    sw.WriteLine("______________________________________________");
                }
            }
            catch 
            {
            }
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
