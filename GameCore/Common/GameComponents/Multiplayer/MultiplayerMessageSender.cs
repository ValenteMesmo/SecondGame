using System;
using NetworkStuff.Udp;
using Common.PubSubEngine;
using Common.GameComponents.PlayerComponents;

namespace Common.GameComponents
{
    internal class MultiplayerMessageSender : IDisposable
    {
        private readonly UdpMessageSender Sender;
        private readonly Sandbox Sandbox;
        private string Ip;
        private int Port;

        public MultiplayerMessageSender(Sandbox sandbox, string ip, int port)
        {
            Ip = ip;
            Port = port;
            Sandbox = sandbox;

            Sender = new UdpMessageSender();
            Sandbox.YouEnteredThePortal.Subscribe(EnteredMultiplayePortal);

            Sandbox.OtherPlayerEnteredAsTheHost.Subscribe(OtherPlayerAsHost, ip);
            Sandbox.OtherPlayerEnteredAsTheGuest.Subscribe(OtherPlayerAsGuest, ip);            
        }

        private void EnteredMultiplayePortal(MultiplayerPortal obj)
        {
            Sender.Send("Connected", obj.Ip, 1337);
            Sandbox.OtherPlayerEnteredAsTheHost.Publish(obj.Ip);
        }

        private void OtherPlayerAsHost()
        {
            Sandbox.PlayerUpdateAfterCollisions.Subscribe(SendUpdateToHost);
        }

        private void OtherPlayerAsGuest()
        {            
            Sandbox.PlayerUpdateAfterCollisions.Subscribe(SendUpdateToGuest);
        }

        private void SendUpdateToHost(Player obj)
        {
            Sender.Send(
            string.Format(
                "gcoord;{0};{1};{2}",
                obj.Body.X,
                obj.Body.Y,
                obj.Body.Name),
            Ip,
            Port);
        }

        private void SendUpdateToGuest(Player obj)
        {
            Sender.Send(
               string.Format(
                   "hcoord;{0};{1};{2}",
                   obj.Body.X,
                   obj.Body.Y,
                   obj.Body.Name),
               Ip,
               Port);
        }

        public void Dispose()
        {
            Sender.Dispose();
        }
    }
}
