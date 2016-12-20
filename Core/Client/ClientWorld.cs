using System;
using Client.Components;
using Client.Components.Factories;
using Common;
using Common.GameComponents.Factories;

namespace Client
{
    public class ClientWorld : World
    {
        public ClientWorld()
        {            
            new ClientPlayerFactory(Sandbox);
            new OtherPlayersFactory(Sandbox);
        }

        protected override void Initialize()
        {
            base.Initialize();
            Sandbox.ClientEvents_PlayerCreated.Subscribe(playerCreated);
            Sandbox.ClientEvents_PlayerCreating.Publish(new Position(4, 4));
        }

        private void playerCreated(Collider obj)
        {
            Disposables.Add(new ListenMessagesFromServer(Sandbox, 1338, obj.Name));
            Disposables.Add(new SendMessagesToServer(Sandbox, "192.168.0.3", 1337));
            Sandbox.Log.Publish(obj.Name);
        }
    }
}
