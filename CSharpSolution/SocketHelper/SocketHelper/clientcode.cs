using SocketHelper;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class ClientClass : IDisposable
{
    string ip;
    int Port;
    Thread threadThatReadsMessagesFromServer;

    public ClientClass(string ip, int port)
    {
        this.ip = ip;
        Port = port;
    }

    NetworkStream networkStream;
    TcpClient socketForServer;
    public void Start(Action<string> onMessageReceived)
    {
        socketForServer = new TcpClient();
        socketForServer.Connect(IPAddress.Parse(ip), Port);

        networkStream = socketForServer.GetStream();

        threadThatReadsMessagesFromServer = Utils.RunInBackground(() =>
        {
            var bytes = new byte[512];
            while (true)
            {
                if (networkStream.DataAvailable)
                {
                    Array.Clear(bytes, 0, bytes.Length);

                    networkStream.Read(bytes, 0, bytes.Length);
                    onMessageReceived(
                        System.Text.Encoding.UTF8.GetString(bytes).TrimEnd()
                    );
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
        if(socketForServer.Connected)
            socketForServer.Close();
    }
}