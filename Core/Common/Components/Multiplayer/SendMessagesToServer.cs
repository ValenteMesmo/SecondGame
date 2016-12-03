using NetworkStuff.Udp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.GameComponents.Multiplayer
{
    public class SendMessagesToServer
    {
        private readonly UdpMessageSender Sender;
        private readonly Sandbox Sandbox;
        private string Ip;
        private int Port;

        public SendMessagesToServer(Sandbox sandbox, string ip, int port)
        {
            Ip = ip;
            Port = port;
            Sandbox = sandbox;

            Sender = new UdpMessageSender();
            //Sandbox.YouEnteredThePortal.Subscribe(EnteredMultiplayePortal);

            //Sandbox.OtherPlayerEnteredAsTheHost.Subscribe(OtherPlayerAsHost, ip);
            //Sandbox.OtherPlayerEnteredAsTheGuest.Subscribe(OtherPlayerAsGuest, ip);
        }

        //private void EnteredMultiplayePortal(MultiplayerPortal obj)
        //{
        //    Sender.Send("Connected", obj.Ip, 1337);
        //    Sandbox.OtherPlayerEnteredAsTheHost.Publish(obj.Ip);
        //}

        //private void OtherPlayerAsHost()
        //{
        //    Sandbox.PlayerUpdateAfterCollisions.Subscribe(SendUpdateToHost);
        //}

        //private void OtherPlayerAsGuest()
        //{
        //    Sandbox.PlayerUpdateAfterCollisions.Subscribe(SendUpdateToGuest);
        //}

        //private void SendUpdateToHost(Player obj)
        //{
        //    Sender.Send(
        //    string.Format(
        //        "gcoord;{0};{1};{2}",
        //        obj.Body.X,
        //        obj.Body.Y,
        //        obj.Body.Name),
        //    Ip,
        //    Port);
        //}

        //private void SendUpdateToGuest(Player obj)
        //{
        //    Sender.Send(
        //       string.Format(
        //           "hcoord;{0};{1};{2}",
        //           obj.Body.X,
        //           obj.Body.Y,
        //           obj.Body.Name),
        //       Ip,
        //       Port);
        //}

        public void Dispose()
        {
            Sender.Dispose();
        }
    }
}
