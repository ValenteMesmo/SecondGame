using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace NetworkStuff.Client
{
    public class NetworkClient : IDisposable
    {
        private Socket Socket;
        private bool IsConnectedToServer = false;
        private NetworkStreamHelper Helper;

        public void Connect(string hostName, int port)
        {
            if (!IsConnectedToServer)
            {
                Socket = new Socket(
                    AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp);
                Socket.Connect(hostName, port);
                IsConnectedToServer = true;

                Helper = new NetworkStreamHelper(
                    new NetworkStream(Socket));
            }

            if (IsConnectedToServer)
            {

            }
        }

        public void Write(string msg)
        {
            Helper.Write(msg);
        }

        public IEnumerable<string> Read()
        {
            // While we are successfully connected, read incoming lines from the server
            while (IsConnectedToServer)
            {
                return Helper.Read();
            }

            return Enumerable.Empty<string>();
        }

        public void Dispose()
        {
            if (Helper != null)
                Helper.Dispose();
            if (Socket != null)
                Socket.Close();
        }
    }
}
