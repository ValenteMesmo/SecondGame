using Core;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

internal class NetworkClient : IDisposable
{
    public Action<string> HandleMessageFromServer = msg => { };
    private Thread threadThatReadsMessagesFromServer;
    private NetworkStream networkStream;
    private TcpClient socketForServer;

    public void Connect(string ip, int port)
    {
        socketForServer = new TcpClient();
        socketForServer.Connect(IPAddress.Parse(ip), port);

        networkStream = socketForServer.GetStream();

        SendMessage("Connected! i should delete this line of code!");

        threadThatReadsMessagesFromServer = Utils.RunInBackground(() =>
        {
            var bytes = new byte[512];
            while (true)
            {
                if (networkStream.DataAvailable)
                {                    
                    networkStream.Read(bytes, 0, bytes.Length);

                    var message = System.Text.Encoding.UTF8.GetString(bytes).TrimEnd();
                    HandleMessageFromServer(message);
                    networkStream.Flush();
                }
            }
        });
    }

    public void SendMessage(string msg)
    {
        var bytes = System.Text.Encoding.UTF8.GetBytes(msg);
        networkStream.Write(bytes, 0, bytes.Length);
    }

    public void Dispose()
    {
        if (threadThatReadsMessagesFromServer != null)
            threadThatReadsMessagesFromServer.Abort();

        if (socketForServer.Connected)
            socketForServer.Close();
    }
}