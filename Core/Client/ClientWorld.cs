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
            //Sandbox.ClientEvents_PlayerCreated.Subscribe(playerCreated);
            Sandbox.ClientEvents_PlayerCreating.Publish(new Position(4, 4));
        }

    }
}
