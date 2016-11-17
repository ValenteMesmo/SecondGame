using System;
using System.Net.Sockets;
using System.Text;

namespace NetworkStuff.Udp
{
    public interface ISendNetworkMessages : IDisposable
    {
        void Write(string message, string ip, int port);
    }

    public class UdpMessageSender : ISendNetworkMessages
    {
        private readonly UdpClient sender;

        public UdpMessageSender()
        {
            sender = new UdpClient();
        }

        public void Dispose()
        {
            sender.Close();
        }

        public void Write(string message, string ip, int port)
        {
            sender.Send(
                Encoding.ASCII.GetBytes(message),
                message.Length,
                ip,
                port);
        }
    }
}
