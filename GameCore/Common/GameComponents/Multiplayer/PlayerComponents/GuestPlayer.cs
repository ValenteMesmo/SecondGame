using Common.PubSubEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.GameComponents.Multiplayer
{
    public class GuestPlayer
    {
        public Collider Body { get; }

        public GuestPlayer(Sandbox sandbox, float x, float y, string hostIp)
        {
            Body = new Collider(sandbox, x, y, 3, 6, GetType());
            sandbox.NetwokMessageReceived.Subscribe(OnMessageReceivedFromHost, hostIp);
        }

        private void OnMessageReceivedFromHost(string message)
        {
            if (message.StartsWith("cord;"))
            {
                var split = message.Split(';');
                Body.X = float.Parse(split[1]);
                Body.Y = float.Parse(split[2]);
            }
        }
    }
}
