using Common;
using NetworkStuff;
using NetworkStuff.Udp;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Client.Components
{
    class ListenMessagesFromServer : IDisposable
    {
        private readonly UdpMessageListener Listener;
        private readonly Sandbox Sandbox;        
        private readonly Position TempPosition;
        private readonly List<string> Names = new List<string>();
        private string PlayerName;

        public ListenMessagesFromServer(Sandbox sandbox, int port, string playerName)
        {
            Sandbox = sandbox;
            TempPosition = new Position(0, 0);
            Listener = new UdpMessageListener(port);
            Listener.Listen(MessageReceived);

            PlayerName = playerName;
        }

        private void MessageReceived(string message, Address source)
        {
            if (message.StartsWith("pp;"))
                PlayerPositionReceived(message, source);
        }

        private void PlayerPositionReceived(string message, Address source)
        {
            var split = message.Split(';');
            TempPosition.X = float.Parse(split[1],CultureInfo.InvariantCulture);
            TempPosition.Y = float.Parse(split[2], CultureInfo.InvariantCulture);

            var name = split[3];

            
            //Sandbox.Log.Publish("opa:   "+  PlayerName + "vs" + name);
            
            if (name != PlayerName)
            {
                if (Names.Contains(name) == false)
                {
                    Names.Add(name);
                    Sandbox.ClinetEvents_OtherPlayerAdded.Publish(name);
                }

                Sandbox.OtherPlayerPositionChanged.Publish(TempPosition, name); 
            }
        }

        public void Dispose()
        {
            Listener.Dispose();
        }
    }
}
