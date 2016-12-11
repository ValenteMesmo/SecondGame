using Common;
using Common.GameComponents.Factories;
using Server.Components;

namespace Server
{
    public class ServerWorld : World
    {
        public ServerWorld()
        {            
            Disposables.Add(new ListenMessagesFromClient(Sandbox, 1337));
            Disposables.Add(new SendMessagesToClient(Sandbox, 1337));
        }

        protected override void Initialize()
        {
            base.Initialize();
            new PlayerFactory(Sandbox);
        }
    }
}
