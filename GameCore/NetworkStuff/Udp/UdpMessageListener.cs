using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NetworkStuff.Udp
{
    public interface IListenToNetworkMessages : IDisposable
    {
        void Listen(Action<string> onMessageReceived);
    }

    public class UdpMessageListener : IListenToNetworkMessages
    {
        private Action<string> OnMessageReceived = msg => { };
        private readonly UdpClient receiver;

        public UdpMessageListener(int receiverPort)
        {
            receiver = new UdpClient(receiverPort);
            receiver.BeginReceive(DataReceived, receiver);
        }

        private void DataReceived(IAsyncResult asyncResult)
        {
            var udpClient = (UdpClient)asyncResult.AsyncState;
            var receivedIpEndPoint = new IPEndPoint(
                IPAddress.Any,
                0);

            try
            {
                byte[] receivedBytes = udpClient.EndReceive(
                       asyncResult,
                       ref receivedIpEndPoint);

                string receivedText = Encoding.ASCII.GetString(
                    receivedBytes);

                OnMessageReceived(receivedText);
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

        public void Listen(Action<string> onMessageReceived)
        {
            OnMessageReceived = onMessageReceived;
        }
    }
}
