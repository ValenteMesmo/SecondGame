using System;
using System.Net.Sockets;
using System.Text;

namespace NetworkStuff.Udp
{
    public interface IWriteNetworkMessages : IDisposable
    {
        void Write(string message);
    }

    public class UdpMessageWriter : IWriteNetworkMessages
    {
        private readonly UdpClient sender;
        private readonly string HostName;
        private readonly int Port;

        public UdpMessageWriter(
            int writerPort,
            string receiverHostName,
            int listenerPort)
        {
            sender = new UdpClient(writerPort);
            HostName = receiverHostName;
            Port = listenerPort;
        }

        public void Dispose()
        {
            sender.Close();
        }

        public void Write(string message)
        {
            sender.Send(
                Encoding.ASCII.GetBytes(message),
                message.Length,
                HostName,
                Port);
        }
    }
}
