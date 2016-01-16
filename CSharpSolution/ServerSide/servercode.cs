using Core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ServerSide
{
    public class ServerClass : IDisposable
    {
        private List<TcpClient> clients = new List<TcpClient>();
        Thread threadThatReadsMessagesFromClients;
        Thread threadThatAcceptsNewClients;
        TcpListener listener;

        public void Start(int port, Action<string> onMessageReceived)
        {
            try
            {
                listener = new TcpListener(GetLocalIPAddress(), port);
                listener.Start();

                AcceptClientConnections(listener);

                ReadMessagesFromClients(onMessageReceived);
            }
            catch (Exception ex)
            {
                Utils.Log(ex.ToString());
            }
        }
        public IPAddress GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    Console.WriteLine(ip.ToString());
                    return ip;
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }


        public void SendMessage(string message)
        {

            var bytes = System.Text.Encoding.UTF8.GetBytes(message);

            for (int i = 0; i < clients.Count; i++)
            {
                try
                {
                    clients[i].GetStream().Write(bytes, 0, bytes.Length);
                }
                catch (Exception ex)
                {
                    clients.Remove(clients[i]);
                    Utils.Log(ex.ToString());
                }
            }

        }

        private void ReadMessagesFromClients(Action<string> onMessageReceived)
        {
            threadThatReadsMessagesFromClients = Utils.RunInBackground(() =>
            {
                string message;
                var bytes = new byte[512];
                NetworkStream stream;

                while (true)
                {
                    try
                    {
                        for (int i = 0; i < clients.Count; i++)
                        {
                            stream = clients[i].GetStream();
                            if (stream.DataAvailable)
                            {
                                Array.Clear(bytes, 0, bytes.Length);

                                stream.Read(bytes, 0, bytes.Length);
                                message = System.Text.Encoding.UTF8.GetString(bytes).TrimEnd();

                                onMessageReceived(message);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Utils.Log(ex.ToString());
                    }
                }
            });
        }

        private void AcceptClientConnections(TcpListener listener)
        {
            TcpClient newClient;
            threadThatAcceptsNewClients = Utils.RunInBackground(() =>
            {
                try
                {
                    while (true)
                    {
                        newClient = listener.AcceptTcpClient();
                        clients.Add(newClient);
                        Console.WriteLine("Client Connected!");
                    }
                }
                catch (Exception ex)
                {
                    Utils.Log(ex.ToString());
                }
            });
        }

        public void Dispose()
        {
            if (threadThatReadsMessagesFromClients != null)
                threadThatReadsMessagesFromClients.Abort();
            if (threadThatAcceptsNewClients != null)
                threadThatAcceptsNewClients.Abort();
            if (listener != null)
                listener.Stop();
        }
    }
}

