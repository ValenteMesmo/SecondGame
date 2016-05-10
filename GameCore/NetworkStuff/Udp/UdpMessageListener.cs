using NetworkStuff.MessageHandlers.Common;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NetworkStuff.Udp
{
    public interface IListenToNetworkMessages : IDisposable
    {
        void Listen(Action<string, Address> onMessageReceived);
        int Port { get; }
        string Ip { get; }
    }

    public class UdpMessageListener : IListenToNetworkMessages
    {
        private Action<string, Address> OnMessageReceived = (msg, address) => { };
        private readonly UdpClient receiver;

        public string Ip { get; private set; }
        public int Port { get; private set; }

        public UdpMessageListener(int receiverPort)
        {
            Ip = NetworkHelper.GetLocalIPAddress();
            Port = receiverPort;

            receiver = new UdpClient(receiverPort);
            receiver.BeginReceive(DataReceived, receiver);
        }

        private void DataReceived(IAsyncResult asyncResult)
        {
            var udpClient = (UdpClient)asyncResult.AsyncState;

            var receivedIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

            try
            {
                byte[] receivedBytes = udpClient.EndReceive(
                       asyncResult,
                       ref receivedIpEndPoint);

                string receivedText = Encoding.ASCII.GetString(
                    receivedBytes);

                OnMessageReceived(
                    receivedText,
                    new Address(
                        receivedIpEndPoint.Address.ToString(),
                        receivedIpEndPoint.Port));
                try
                {
                    udpClient.BeginReceive(DataReceived, asyncResult.AsyncState);
                }
                catch (SocketException) { }
            }
            catch (ObjectDisposedException) { }
        }

        public void Dispose()
        {
            receiver.Close();
        }

        public void Listen(Action<string, Address> onMessageReceived)
        {
            OnMessageReceived = onMessageReceived;
        }
    }
}
