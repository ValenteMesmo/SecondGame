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
            Sandbox.GuestJoined.Subscribe(GuestJoined, Ip);
            Sandbox.CloseThePortal.Subscribe(Dispose, Ip);
        }

        private void GuestJoined()
        {
            new Guest(Sandbox, 0, 0);
            Sandbox.CloseThePortal.Publish(Ip);
        }

        public void Dispose()
        {
        }
    }
}
