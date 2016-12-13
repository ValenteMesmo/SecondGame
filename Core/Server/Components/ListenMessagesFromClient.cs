using Common;
using NetworkStuff.Udp;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Server.Components
{
    internal class ListenMessagesFromClient : IDisposable
    {
        private readonly UdpMessageListener Listener;
        private readonly Sandbox Sandbox;
        private readonly Position TempPosition;
        private readonly List<string> Names = new List<string>();

        public ListenMessagesFromClient(Sandbox sandbox, int port)
        {
            Sandbox = sandbox;
            Listener = new UdpMessageListener(port);
            Listener.Listen(MessageReceived);
            TempPosition = new Position(0, 0);
        }

        private void MessageReceived(string message, string source)
        {
            //if (message == "Connected")
            //    PlayerConnected(source);
            //Sandbox.Log.Publish(message);
            if (message.StartsWith("pp;"))
                PlayerInputReceived(message, source);
        }

        private void PlayerInputReceived(string message, string source)
        {
            var split = message.Split(';');
            //for (int i = 1; i < split.Length; i++)
            //{
            //    switch (split[i].ToLower())
            //    {
            //        case "a":
            //            break;
            //        case "s":
            //            break;
            //        case "d":
            //            break;
            //        case "w":
            //            break;
            //        case "j":
            //            break;
            //        case "k":
            //            break;
            //        case "l":
            //            break;
            //        default:
            //            break;
            //    }

            //}
            TempPosition.X = float.Parse(split[1], CultureInfo.InvariantCulture);
            TempPosition.Y = float.Parse(split[2], CultureInfo.InvariantCulture);

            var name = split[3];

            if (Names.Contains(name) == false)
            {
                Names.Add(name);
                Sandbox.ServerEvents_PlayerAdded.Publish(name);
                Sandbox.ServerEvents_PlayerConnected.Publish(source);
            }

            Sandbox.PositionReceivedFromClient.Publish(TempPosition, name);
            Sandbox.Log.Publish("server received: " + source);
        }        

        //private void PlayerConnected(Address source)
        //{
        //    Sandbox.ServerEvents_PlayerConnected.Publish(source);
        //    //usar o playerConnected no playerfactory... em vez do player added?
        //    Sandbox.ClientEvents_PlayerAdded.Publish(new Position(0,0));
        //    //Transformar sandbox em abstrato para ter umva versao client e outra server?
        //}

        public void Dispose()
        {
            Listener.Dispose();
        }
    }
}
