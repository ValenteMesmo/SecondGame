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
        private Action<string, Address> OnMessageReceived = (msg, endpoint) => { };
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

                OnMessageReceived(receivedText,
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

        //private Endpoint GetIpAndPort(UdpClient udpClient)
        //{
        //    try
        //    {
        //        IPEndPoint remoteIpEndPoint =
        //               udpClient.Client.RemoteEndPoint as IPEndPoint;

        //        if (remoteIpEndPoint == null)
        //            throw new SocketException();

        //        return new Endpoint(
        //            remoteIpEndPoint.Address.ToString(),
        //            remoteIpEndPoint.Port);
        //    }
        //    catch (SocketException ex)
        //    {
        //        IPEndPoint localIpEndPoint =
        //        udpClient.Client.LocalEndPoint as IPEndPoint;

        //        if (localIpEndPoint == null)
        //            throw ex;

        //        if (localIpEndPoint.Address.ToString() == "0.0.0.0")
        //            return new Endpoint(
        //            "localhost",
        //            localIpEndPoint.Port);

        //        return new Endpoint(
        //            localIpEndPoint.Address.ToString(),
        //            localIpEndPoint.Port);
        //    }
        //}

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
