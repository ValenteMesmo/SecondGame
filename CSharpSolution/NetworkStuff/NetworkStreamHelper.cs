using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;

namespace NetworkStuff
{
    public class NetworkStreamHelper : IDisposable
    {
        NetworkStream NetworkStream;
        StreamReader StreamReader;
        StreamWriter StreamWriter;

        public NetworkStreamHelper(NetworkStream networkStream)
        {
            NetworkStream = networkStream;
            StreamReader = new StreamReader(networkStream);
            StreamWriter = new StreamWriter(networkStream);
        }

        public void Dispose()
        {
            StreamWriter.Dispose();
            StreamReader.Dispose();
            NetworkStream.Dispose();
        }

        public IEnumerable<string> Read()
        {
            var result = new char[128];
            if (NetworkStream.DataAvailable)
            {
                StreamReader.Read(result, 0, result.Length);
                NetworkStream.Flush();
            }
            return
                new string(result).Replace("\0", string.Empty)
                .Split(new string[] { "<EOS>" }, StringSplitOptions.RemoveEmptyEntries);
        }

        public void Write(string msg)
        {
            StreamWriter.Write(msg + "<EOS>");
            StreamWriter.Flush();
        }
    }
}
