using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
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

        [Obsolete("This was a lazy solution... something better needs to be done!")]
        public static IPAddress GetIp()
        {
            return Dns.Resolve(Dns.GetHostName()).AddressList[0];
        }

        public void Dispose()
        {
            StreamWriter.Dispose();
            StreamReader.Dispose();
            NetworkStream.Dispose();
        }

        public ICollection<string> Read()
        {
            var result = new char[512];
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
