using Common;
using NetworkStuff.Udp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.Components
{
    class SendMessagesToServer
    {
        private readonly UdpMessageSender Sender;
        private readonly Sandbox Sandbox;

        public SendMessagesToServer(Sandbox sandbox, int port)
        {
            Sandbox = sandbox;
            Sender = new UdpMessageSender();
        }

        public void Dispose()
        {
            Sender.Dispose();
        }
    }
}
