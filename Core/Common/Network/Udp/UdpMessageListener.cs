using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NetworkStuff.Udp
{
    public interface IListenToNetworkMessages : IDisposable
    {
        void Listen(Action<string, Address> onMessageReceived);
    }

    public class UdpMessageListener : IListenToNetworkMessages
    {
        private Action<string, Address> OnMessageReceived = (msg, address) => { };
        private readonly UdpClient receiver;

        public UdpMessageListener(int port)
        {
            receiver = CreateReceiver(port);
        }

        private UdpClient CreateReceiver(int port)
        {
            //try
            //{
                var receiver = new UdpClient(port);
                receiver.BeginReceive(DataReceived, receiver);
                return receiver;
            //}
            //catch (SocketException)
            //{
            //    return CreateReceiver(++port);
            //}
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
