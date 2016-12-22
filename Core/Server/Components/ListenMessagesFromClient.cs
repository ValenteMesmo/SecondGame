using Common;
using NetworkStuff.Udp;
using System;
using System.Collections.Generic;

namespace Server.Components
{
    internal class ListenMessagesFromClient : IDisposable
    {
        private readonly UdpMessageListener Listener;
        private readonly Sandbox Sandbox;
        private readonly List<string> Names = new List<string>();

        public ListenMessagesFromClient(Sandbox sandbox, int port)
        {
            Sandbox = sandbox;
            Listener = new UdpMessageListener(port);
            Listener.Listen(MessageReceived);
            Sandbox.OnWorldUpdateAfterCollisions.Subscribe(AfterWorldUpdate);
        }

        private void AfterWorldUpdate()
        {
            foreach (var name in Names)
            {
                Sandbox.LeftPressed.Publish(false, name);
                Sandbox.RightPressed.Publish(false, name);
                Sandbox.UpPressed.Publish(false, name);
            }
        }

        private void MessageReceived(string message, string source)
        {
            //if (message == "Connected")
            //    PlayerConnected(source);
            //Sandbox.Log.Publish(message);
            if (message.StartsWith("ipt;"))
                PlayerInputReceived(message, source);
        }

        private void PlayerInputReceived(string message, string source)
        {
            var split = message.Split(';');

            var name = split[1];
            if (Names.Contains(name) == false)
            {
                Names.Add(name);
                Sandbox.ServerEvents_PlayerAdded.Publish(name);
                Sandbox.ServerEvents_PlayerConnected.Publish(source);
            }

            for (int i = 1; i < split.Length; i++)
            {
                switch (split[i].ToLower())
                {
                    case "a":
                        Sandbox.LeftPressed.Publish(true, name);
                        break;
                    case "s":                        
                        break;
                    case "d":
                        Sandbox.RightPressed.Publish(true, name);
                        break;
                    case "w":
                        Sandbox.UpPressed.Publish(true, name);
                        break;
                    case "j":
                        break;
                    case "k":
                        Sandbox.UpPressed.Publish(true, name);
                        break;
                    case "l":
                        break;
                    default:
                        break;
                }
            }
        }

        public void Dispose()
        {
            Listener.Dispose();
        }
    }
}
