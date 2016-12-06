using Common;
using Common.GameComponents;
using Server.GameComponents;

namespace Server
{
    public class ServerWorld : World
    {
        public ServerWorld()
        {            
            Disposables.Add(new ListenMessagesFromClient(Sandbox, 1337));
        }
    }
}
