using Common;
using NetworkStuff;
using NetworkStuff.Udp;
using System;

namespace Server.GameComponents
{
    internal class ListenMessagesFromClient : IDisposable
    {
        private readonly UdpMessageListener Listener;
        private readonly Sandbox Sandbox;
        private readonly Position TempPosition;

        public ListenMessagesFromClient(Sandbox sandbox, int port)
        {
            Sandbox = sandbox;
            Listener = new UdpMessageListener(port);
            Listener.Listen(MessageReceived);
            TempPosition = new Position(0, 0);
        }

        private void MessageReceived(string message, Address source)
        {
            if (message == "Connected")
                PlayerConnected(source);

            if (message.StartsWith("pp;"))
                PlayerInputReceived(message, source);
        }

        private void PlayerInputReceived(string message, Address source)
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
            TempPosition.X = float.Parse(split[1]);
            TempPosition.Y = float.Parse(split[2]);
            var name = split[3];

            Sandbox.PositionReceivedFromClient.Publish(TempPosition, name);
        }

        private void PlayerConnected(Address source)
        {
            Sandbox.PlayerConnected.Publish(source);
            //usar o playerConnected no playerfactory... em vez do player added?
            Sandbox.PlayerAdded.Publish(new Position(0,0));
            //Transformar sandbox em abstrato para ter umva versao client e outra server?
        }

        public void Dispose()
        {
            Listener.Dispose();
        }
    }
}
