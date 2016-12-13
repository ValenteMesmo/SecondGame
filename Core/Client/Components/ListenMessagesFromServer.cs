using Common;
using NetworkStuff;
using NetworkStuff.Udp;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Client.Components
{
    class ListenMessagesFromServer : IDisposable
    {//fazer o esquema de guardar mensagens para rodar na thread do unity aqui... centralizado
        private readonly UdpMessageListener Listener;
        private readonly Sandbox Sandbox;        
        private readonly Position TempPosition;
        private readonly List<string> Names = new List<string>();
        private string PlayerName;

        public ListenMessagesFromServer(Sandbox sandbox, int port, string playerName)
        {
            Sandbox = sandbox;
            TempPosition = new Position(0, 0);
            Listener = new UdpMessageListener(port);
            Listener.Listen(MessageReceived);

            PlayerName = playerName;
            Sandbox.OnWorldUpdateAfterCollisions.Subscribe(WorldUpdate);
        }

        private readonly List<Action> RunOnUnityThread = new List<Action>();

        private void WorldUpdate()
        {
            var excetutionList = RunOnUnityThread.ToArray();

            for (int i = 0; i < excetutionList.Length; i++)
            {
                excetutionList[i]();
                RunOnUnityThread.Remove(excetutionList[i]);
            }            
        }

        private void MessageReceived(string message, string source)
        {
            if (message.StartsWith("pp;"))
                PlayerPositionReceived(message, source);
        }

        private void PlayerPositionReceived(string message, string source)
        {
            var split = message.Split(';');
            TempPosition.X = float.Parse(split[1],CultureInfo.InvariantCulture);
            TempPosition.Y = float.Parse(split[2], CultureInfo.InvariantCulture);

            var name = split[3];

            
            //Sandbox.Log.Publish("opa:   "+  PlayerName + "vs" + name);
            
            if (name != PlayerName)
            {
                if (Names.Contains(name) == false)
                {
                    Names.Add(name);
                    RunOnUnityThread.Add(() =>
                    Sandbox.ClinetEvents_OtherPlayerAdded.Publish(name));
                }
                RunOnUnityThread.Add(()=> 
                Sandbox.OtherPlayerPositionChanged.Publish(TempPosition, name));
                Sandbox.Log.Publish("client received: " + source);
            }
        }

        public void Dispose()
        {
            Listener.Dispose();
        }
    }
}
