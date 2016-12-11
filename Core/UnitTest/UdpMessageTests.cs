using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetworkStuff.Udp;

namespace NetworkStuff.Tests
{
    [TestClass]
    public class UdpMessageTests
    {
        [TestMethod]
        public void ShouldReceiveAtLeastMessage()
        {
            var listenerPort = 20000;
            var expectedMessage = "Opa! excelente~";

            var listener = new UdpMessageListener(listenerPort);
            listener.Listen((actualMessage, address) =>
            {
                Assert.AreEqual(expectedMessage, actualMessage);
                AsyncAssert.Done();
            });

            var writer = new UdpMessageSender();
            writer.Send(expectedMessage, "localhost", listenerPort);

            AsyncAssert.Wait();

            writer.Dispose();
            listener.Dispose();
        }

        [TestMethod]
        public void ShouldReceiveMessagesFromMultipleSources()
        {
            var listenerPort = 20002;

            var expectedMessages = new string[] { "msg 1", "msg 2" };

            var listener = new UdpMessageListener(listenerPort);
            var count = 0;
            listener.Listen((actualMessage, address) =>
            {
                count++;
                Assert.IsTrue(expectedMessages.Contains(actualMessage));
                if (count >= 2)
                    AsyncAssert.Done();
            });

            var writer1 = new UdpMessageSender();

            var writer2 = new UdpMessageSender();

            writer1.Send(expectedMessages[0], "localhost", listenerPort);
            writer2.Send(expectedMessages[1], "localhost", listenerPort);

            AsyncAssert.Wait();

            writer1.Dispose();
            writer2.Dispose();
            listener.Dispose();
        }

        [TestMethod]
        public void Should_use_other_port_if_current_is_unavailabe()
        {
            var sut = new Udp.UdpMessageListener(1337);
            var sut2 = new Udp.UdpMessageListener(1337);
            var sut3 = new Udp.UdpMessageListener(1337);
        }
    }
}
