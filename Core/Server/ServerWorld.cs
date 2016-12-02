using Common;
using Common.GameComponents;

namespace Server
{
    public class ServerWorld : World
    {
        public ServerWorld()
        {
            Disposables.Add(new MultiplayerMessageListener(Sandbox, 1337));
        }
    }
}
