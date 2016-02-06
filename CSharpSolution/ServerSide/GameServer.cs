using NetworkStuff.Server;
using System;

namespace ServerSide
{
    public class GameServer : IDisposable
    {
        private NetworkServer network;
        private World world;

        public GameServer()
        {
            network = new NetworkServer();
            world = new World(SomethingChanged_Callback);
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
                var block = new Block("block_A" + i, world.CollisionContext);
                block.Y.SetValue(-2);
                block.X.SetValue(i * -0.8f);
                world.AddThing(block);
            }

            for (int i = 1; i < 20; i++)
            {
                var block = new Block("block_B" + i, world.CollisionContext);
                block.Y.SetValue(-2);
                block.X.SetValue(i * 0.8f);
                world.AddThing(block);
            }
        }

        int playercount = 0;
        private void HandleMessageFromClients(string id, string message)
        {
            //only inputs?
            //should i add a handler for new connections?
            //shound i categorize messages?  newPlayer, thingUpdate, playerLeft, etc
            var player = new Player("player" + ++playercount, world.CollisionContext);
            player.X.SetValue(playercount);
            world.AddThing(player);
        }

        public void Dispose()
        {
            network.Dispose();
            world.Dispose();
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