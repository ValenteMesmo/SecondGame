using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetworkStuff.Udp;

namespace NetworkStuff.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldReceiveAMessage()
        {
            var listenerPort = 20000;
            var writerPort = 20001;
            var expectedMessage = "Opa! excelente~";

            var sut = new UdpMessageListener(listenerPort);
            var writer = new UdpMessageWriter(
                writerPort,
                "localhost",
                listenerPort);

            sut.Listen(actualMessage =>
            {
                Assert.AreEqual(expectedMessage, actualMessage);
                AsyncAssert.Done();
            });

            writer.Write(expectedMessage);

            AsyncAssert.Wait();

            sut.Dispose();
            writer.Dispose();
        }

        [TestMethod]
        public void ShouldReceiveMessagesFromMultipleSources()
        {
            var listenerPort = 20000;
            var writer1Port = 20001;
            var writer2Port = 20002;

            var expectedMessages = new string[] {"msg 1", "msg 2" };        

            var sut = new UdpMessageListener(listenerPort);

            var writer1 = new UdpMessageWriter(
                writer1Port,
                "localhost",
                listenerPort);

            var writer2 = new UdpMessageWriter(
                writer2Port,
                "localhost",
                listenerPort);

            var count = 0;
            sut.Listen(actualMessage =>
            {
                count++;
                Assert.IsTrue(expectedMessages.Contains(actualMessage));
                if (count >= 2)
                    AsyncAssert.Done();
            });

            writer1.Write(expectedMessages[0]);
            writer2.Write(expectedMessages[1]);

            AsyncAssert.Wait();

            sut.Dispose();
            writer1.Dispose();
            writer2.Dispose();
        }
    }
}
