﻿using Client.Components;
using Common;
using Common.GameComponents;
using Common.GameComponents.Factories;

namespace Client
{
    public class ClientWorld : World
    {
        public ClientWorld()
        {            
            new ClientPlayerFactory(Sandbox);
            Disposables.Add(new ListenMessagesFromServer(Sandbox, 1337));
            Disposables.Add(new SendMessagesToServer(Sandbox, "192.168.0.3", 1337));
            //}
        }

        protected override void Initialize()
        {
            base.Initialize();
            Sandbox.ClientEvents_PlayerAdded.Publish(new Position(4, 4));
        }
    }
}
