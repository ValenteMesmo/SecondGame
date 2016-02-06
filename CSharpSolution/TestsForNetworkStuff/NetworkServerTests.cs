using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetworkStuff.Server;
using System.Threading;
using NetworkStuff.Client;
using NetworkStuff;

namespace TestsForNetworkStuff
{
    [TestClass]
    public class NetworkServerTests
    {
        [TestMethod]
        public void ShouldStartListeningWithoutErrors()
        {
            using (var sut = new NetworkServer())
            {
                sut.startListener(1337);

                Assert.IsTrue(sut.IsServerRunning);
            }
        }

        [TestMethod]
        public void ShouldAcceptClientConnections()
        {
            using (var sut = new NetworkServer())
            {
                sut.startListener(1337);

                using (var client = new NetworkClient())
                {
                    client.Connect(NetworkStreamHelper.GetIp().ToString(), 1337);

                    Thread.Sleep(50);

                    Assert.AreEqual(1, sut.GetClients().Count);
                }                
            }
        }

        [TestMethod]
        public void ServerShouldReceiveClientsMessage()
        {
            var messageToSend = "Hello world";

            using (var sut = new NetworkServer())
            {
                sut.startListener(1337);

                using (var client = new NetworkClient())
                {
                    client.Connect(NetworkStreamHelper.GetIp().ToString(), 1337);

                    Thread.Sleep(50);

                    client.Write(messageToSend);

                    var receivedMessage =  
                        sut.GetClients()
                        .First()
                        .Read()
                        .FirstOrDefault();

                    Assert.AreEqual(messageToSend, receivedMessage);
                }
            }
        }

        [TestMethod]
        public void ServerShouldReceiveAllClientsMessage()
        {
            var messageToSend1 = "Hello world";
            var messageToSend2 = "hehehe";

            using (var sut = new NetworkServer())
            {
                sut.startListener(1337);

                using (var client = new NetworkClient())
                {
                    client.Connect(NetworkStreamHelper.GetIp().ToString(), 1337);

                    Thread.Sleep(50);

                    client.Write(messageToSend1);
                    client.Write(messageToSend2);

                    var receivedMessages =
                        sut.GetClients()
                        .First()
                        .Read();

                    Assert.AreEqual(2, receivedMessages.Count);
                    Assert.AreEqual(messageToSend1, receivedMessages.FirstOrDefault());
                    Assert.AreEqual(messageToSend2, receivedMessages.Skip(1).FirstOrDefault());
                }
            }
        }
    }
}
