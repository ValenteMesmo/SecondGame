using NetworkStuff.Server;
using System;
using System.Net;

namespace ServerSide
{
    public class GameServer : IDisposable
    {
        private NetworkServer network;
        private IWorld World;
        int playercount = 0;
        public readonly string Ip;

        public GameServer(IWorld world)
        {
            network = new NetworkServer();
            World = world;
            World.SetActionToBeCalledWhenSomethingChanges(SomethingChanged_Callback);
            Ip = network.Ip.ToString();
        }

        public void Start(int hostPort)
        {
            CreatePlatforms();
            network.startListener(hostPort);
        }

        private void CreatePlatforms()
        {
            for (int i = 0; i < 20; i++)
            {
                var block = new Block("block_A" + i, World.CollisionContext);
                block.Y.SetValue(-2);
                block.X.SetValue(i * -0.8f);
                World.AddThing(block);
            }

            for (int i = 1; i < 20; i++)
            {
                var block = new Block("block_B" + i, World.CollisionContext);
                block.Y.SetValue(-2);
                block.X.SetValue(i * 0.8f);
                World.AddThing(block);
            }
        }

        private void HandleMessageFromClients(string id, string message)
        {
            //only inputs?
            //should i add a handler for new connections?
            //shound i categorize messages?  newPlayer, thingUpdate, playerLeft, etc
            var player = new Player("player" + ++playercount, World.CollisionContext);
            player.X.SetValue(playercount);
            World.AddThing(player);
        }

        public void Dispose()
        {
            network.Dispose();
            World.Dispose();
        }

        private void SomethingChanged_Callback(Thing thing)
        {
            foreach (var client in network.GetClients())
            {
                client.Write(string.Join("|", new[] {
                    thing.Id,
                    thing.X.GetValue().ToString(),
                    thing.Y.GetValue().ToString(),
                    thing.Velocity_X.GetValue().ToString(),
                    thing.Velocity_Y.GetValue().ToString()
                }));
            }
        }
    }
}