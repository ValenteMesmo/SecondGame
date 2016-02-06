using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace NetworkStuff.Client
{
    public class NetworkClient
    {
        private TcpClient tcpClient;
        private bool IsConnectedToServer = false;
        private NetworkStreamHelper Helper;

        public void Connect(string hostName, int port)
        {
            if (!IsConnectedToServer)
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(hostName, port);
                IsConnectedToServer = true;

                Helper = new NetworkStreamHelper( tcpClient.GetStream());
            }

            if (IsConnectedToServer)
            {

            }
        }

        public void Write(string msg)
        {
            Helper.Write(msg);            
        }

        private IEnumerable<string> Read()
        {
            // While we are successfully connected, read incoming lines from the server
            while (IsConnectedToServer)
            {
                return Helper.Read();
            }

            return Enumerable.Empty<string>();
        }
    }
}
