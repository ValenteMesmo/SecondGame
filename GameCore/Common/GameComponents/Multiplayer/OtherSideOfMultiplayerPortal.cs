using Common.PubSubEngine;
using Common.GameComponents.Multiplayer;
using System;

namespace Common.GameComponents
{
    internal class OtherSideOfMultiplayerPortal : IDisposable
    {
        public Sandbox Sandbox { get; }
        public string Ip { get; }

        public OtherSideOfMultiplayerPortal(Sandbox sandbox, string ip, float x, float y)
        {
            Sandbox = sandbox;
            Ip = ip;
            Sandbox.SendNetwokMessage.Subscribe(OnMessageReceived, Ip);
            Sandbox.CloseThePortal.Subscribe(Dispose, Ip);
        }

        private void OnMessageReceived(string message)
        {
            new GuestPlayer(Sandbox, 0, 0, Ip);
            Sandbox.CloseThePortal.Publish(Ip);
        }

        public void Dispose()
        {            
        }
    }
}
