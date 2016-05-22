using System;
using System.Net.Sockets;
using System.Text;

namespace NetworkStuff.Udp
{
    public interface IWriteNetworkMessages : IDisposable
    {
        void Write(string message, string hostName, int port);
    }

    public class UdpMessageWriter : IWriteNetworkMessages
    {
        private readonly UdpClient sender;

        public UdpMessageWriter()
        {
            sender = new UdpClient();
        }

        public void Dispose()
        {
            sender.Close();
        }

        public void Write(string message, string hostName, int port)
        {
            sender.Send(
                Encoding.ASCII.GetBytes(message),
                message.Length,
                hostName,
                port);
        }
    }
}
