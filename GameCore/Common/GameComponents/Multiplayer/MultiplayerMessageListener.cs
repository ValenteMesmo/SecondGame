using System;
using NetworkStuff;
using NetworkStuff.Udp;
using Common.PubSubEngine;
using System.Collections.Generic;

namespace Common.GameComponents
{
    internal class MultiplayerMessageListener : IDisposable
    {
        private readonly UdpMessageListener Listener;
        private readonly Sandbox Sandbox;
        private readonly Dictionary<string, Collider> Colliders;

        public MultiplayerMessageListener(Sandbox sandbox, int port)
        {
            Sandbox = sandbox;
            Colliders = new Dictionary<string, Collider>();
            Listener = new UdpMessageListener(port);
            Listener.Listen(MessageReceived);
        }

        private void MessageReceived(string message, Address source)
        {
            if (message == "Connected")
                Sandbox.OtherPlayerEnteredAsTheGuest.Publish(source.Ip);

            if (message.StartsWith("hcoord;"))
            {
                var split = message.Split(';');
                var name = split[3];
                if (Colliders.ContainsKey(name) == false)
                    Colliders.Add(name, new Collider(Sandbox, 0, 0, 3, 6, typeof(PlayerComponents.Player)));

                Colliders[name].X = float.Parse(split[1]);
                Colliders[name].Y = float.Parse(split[2]);
                Sandbox.HostPosiitonUpdate.Publish(Colliders[name]);
            }

            if (message.StartsWith("gcoord;"))
            {
                var split = message.Split(';');
                var name = split[3];
                if (Colliders.ContainsKey(name) == false)
                    Colliders.Add(name, new Collider(Sandbox, 0, 0, 3, 6, typeof(PlayerComponents.Player)));

                Colliders[name].X = float.Parse(split[1]);
                Colliders[name].Y = float.Parse(split[2]);
                Sandbox.GuestPosiitonUpdate.Publish(Colliders[name]);
            }
        }

        public void Dispose()
        {
            Listener.Dispose();
        }
    }
}
