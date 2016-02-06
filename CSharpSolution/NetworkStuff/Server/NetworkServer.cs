using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace NetworkStuff.Server
{
    public class NetworkServer : IDisposable
    {
        public bool IsServerRunning;
        Socket socket;

        private List<NetworkServersClient> Clients = new List<NetworkServersClient>();
        public ICollection<NetworkServersClient> GetClients() { return Clients.ToArray(); }

        private IPAddress _ip;
        public IPAddress GetIp()
        {
            if (_ip == null)
                _ip = Dns.Resolve(Dns.GetHostName()).AddressList[0]; 
            return _ip;
        }

        public void startListener(int serverPort)
        {
            Console.WriteLine(GetIp().ToString());

            IPEndPoint localEndPoint = new IPEndPoint(GetIp(), serverPort);

            if (IsServerRunning)
                throw new Exception("This ChatServer is already running!");

            socket = new Socket(
               AddressFamily.InterNetwork,
               SocketType.Stream,
               ProtocolType.Tcp);

            socket.Bind(localEndPoint);
            socket.Listen(10);

            IsServerRunning = true;

            socket.BeginAccept(NewClientConnected, null);
        }

        private void NewClientConnected(IAsyncResult ar)
        {
            try
            {
                var client = socket.EndAccept(ar);
                socket.BeginAccept(NewClientConnected, null);

                Clients.Add(new NetworkServersClient(client));
            }
            catch (ObjectDisposedException)
            {
            }
        }

        public void Dispose()
        {
            foreach (var client in Clients)
            {
                client.Dispose();
            }

            socket.Close();
        }
    }
}
