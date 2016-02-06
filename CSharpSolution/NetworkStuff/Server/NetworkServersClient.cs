using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;

namespace NetworkStuff.Server
{
    public class NetworkServersClient : IDisposable
    {
        private NetworkStreamHelper Helper;

        public NetworkServersClient(Socket client)
        {
            Helper = new NetworkStreamHelper(
                new NetworkStream(client));
        }

        public void Dispose()
        {
            Helper.Dispose();
        }

        public ICollection<string> Read()
        {
            return Helper.Read();
        }

        public void Write(string msg)
        {
            Helper.Write(msg);
        }
    }
}
