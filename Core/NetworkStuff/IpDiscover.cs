﻿using NetworkStuff.Udp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;

namespace NetworkStuff.MessageHandlers.Common
{
    public class IpDiscover : IDisposable
    {
        private readonly UdpMessageSender sender;
        private readonly UdpMessageListener listener;
        private readonly int port;
        private readonly string myIp;
        private readonly string broadcastIp;
        private readonly Thread broadcastLoop;
        private readonly Action<string> OnNewIpDiscovered;
        private readonly List<string> IpsFound;

        public IpDiscover(Action<string> onNewIpDiscovered)
        {
            IpsFound = new List<string>();
            OnNewIpDiscovered = onNewIpDiscovered;
            port = 47777;
            myIp = NetworkHelper.GetLocalIPAddress();
            broadcastIp = NetworkHelper.GetBroadcastAddress(
                IPAddress.Parse(myIp),
                IPAddress.Parse("255.255.255.0")).ToString();
            listener = new UdpMessageListener(port);
            sender = new UdpMessageSender();
            listener.Listen(OnMessageReceived);

            var operation = new ParameterizedThreadStart(Broadcast);
            broadcastLoop = new Thread(operation, 1024 * 1024);
            broadcastLoop.Start();
        }

        private void Broadcast(object obj)
        {
            while (true)
            {
                sender.Send("Hello", broadcastIp, port);
                Thread.Sleep(1000);
            }
        }

        private void OnMessageReceived(string message, Address sourceAddress)
        {
            if (sourceAddress.Ip != myIp && IpsFound.Contains(sourceAddress.Ip) == false)
            {
                IpsFound.Add(sourceAddress.Ip);
                OnNewIpDiscovered(sourceAddress.Ip);
                sender.Send("Hello", sourceAddress.Ip, sourceAddress.Port);
            }
        }

        public void Dispose()
        {
            broadcastLoop.Abort();
            sender.Dispose();
            listener.Dispose();
        }
    }
}
