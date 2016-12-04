using Common;
using NetworkStuff;
using NetworkStuff.Udp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.Components
{
    class ListenMessagesFromServer
    {
        private readonly UdpMessageListener Listener;
        private readonly Sandbox Sandbox;

        public ListenMessagesFromServer(Sandbox sandbox, int port)
        {
            Sandbox = sandbox;
            Listener = new UdpMessageListener(port);
            Listener.Listen(MessageReceived);
        }

        private void MessageReceived(string message, Address source)
        {
            if (message.StartsWith("pp;"))
                PlayerPositionReceived(message, source);
        }

        private void PlayerPositionReceived(string message, Address source)
        {
            
        }

        public void Dispose()
        {
            Listener.Dispose();
        }
    }
}
