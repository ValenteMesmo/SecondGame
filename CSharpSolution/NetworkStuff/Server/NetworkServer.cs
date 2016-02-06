using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace NetworkStuff.Server
{
    public class NetworkServer
    {
        public bool IsServerRunning;
        Socket socket;

        private List<NetworkServersClient> Clients = new List<NetworkServersClient>();
        public IEnumerable<NetworkServersClient> GetClients() { return Clients.ToArray(); }

        public void startListener(int serverPort)
        {
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];

            Console.WriteLine(ipAddress.ToString());

            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, serverPort);

            if (IsServerRunning)
                throw new Exception("This ChatServer is already running!");

            socket = new Socket(
               AddressFamily.InterNetwork,
               SocketType.Stream,
               ProtocolType.Tcp);

            socket.Bind(localEndPoint);
            socket.Listen(100);

            IsServerRunning = true;

            socket.BeginAccept(NewClientConnected, null);
        }

        private void NewClientConnected(IAsyncResult ar)
        {
            var client = socket.EndAccept(ar);
            socket.BeginAccept(NewClientConnected, null);

            Clients.Add(new NetworkServersClient(client));
        }
    }
}
