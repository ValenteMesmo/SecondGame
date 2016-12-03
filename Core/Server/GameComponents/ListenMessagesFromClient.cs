using Common;
using NetworkStuff;
using NetworkStuff.Udp;
using System;
using System.Collections.Generic;

namespace Server.GameComponents
{
    internal class ListenMessagesFromClient : IDisposable
    {
        private readonly UdpMessageListener Listener;
        private readonly Sandbox Sandbox;
        private readonly Dictionary<string, Collider> Colliders;

        public ListenMessagesFromClient(Sandbox sandbox, int port)
        {
            Sandbox = sandbox;
            Colliders = new Dictionary<string, Collider>();
            Listener = new UdpMessageListener(port);
            Listener.Listen(MessageReceived);
        }

        private void MessageReceived(string message, Address source)
        {
            if (message == "Connected")
                PlayerConnected(source);

            if (message.StartsWith("input;"))
                PlayerInputReceived(message, source);
        }

        private static void PlayerInputReceived(string message, Address source)
        {
            var split = message.Split(';');
            for (int i = 1; i < split.Length; i++)
            {
                switch (split[i].ToLower())
                {
                    case "a":
                        break;
                    case "s":
                        break;
                    case "d":
                        break;
                    case "w":
                        break;
                    case "j":
                        break;
                    case "k":
                        break;
                    case "l":
                        break;
                    default:
                        break;
                }

            }
        }

        private void PlayerConnected(Address source)
        {
            Sandbox.PlayerAdded.Publish(new Position(0,0));
        }

        public void Dispose()
        {
            Listener.Dispose();
        }
    }
}
