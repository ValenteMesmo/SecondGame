
using NetworkStuff.MessageHandlers.Common;
using System;

namespace Common.GameComponents.Multiplayer
{
    public class FindPlayersOnLocalAreaNetwork : IDisposable
    {
        private readonly IpDiscover IpFinder;
        private readonly Sandbox Sandbox;

        public FindPlayersOnLocalAreaNetwork(Sandbox sandbox)
        {
            Sandbox = sandbox;
            IpFinder = new IpDiscover(OnPlayerFound);
        }

        private void OnPlayerFound(string ip)
        {            
            Sandbox.FoundNewIP.Publish(ip);
        }

        public void Dispose()
        {
            IpFinder.Dispose();
        }
    }
}
