using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetworkStuff.Udp;
using System;

namespace NetworkStuff.Tests
{
    [TestClass]
    public class UdpMessageTests
    {
        [TestMethod]
        public void ShouldReceiveAtLeastMessage()
        {
            var listenerPort = 20000;
            var writerPort = 20001;
            var expectedMessage = "Opa! excelente~";

            using (var listener = new UdpMessageListener(listenerPort))
            {
                using (var writer = new UdpMessageWriter(writerPort))
                {

                    listener.Listen(actualMessage =>
                    {
                        Assert.AreEqual(expectedMessage, actualMessage);
                        AsyncAssert.Done();
                    });

                    writer.Write(expectedMessage, "localhost", listenerPort);

                    AsyncAssert.Wait(100);

                }
            }
        }

        [TestMethod]
        public void ShouldReceiveMessagesFromMultipleSources()
        {
            var listenerPort = 20002;
            var writer1Port = 20003;
            var writer2Port = 20004;

            var expectedMessages = new string[] { "msg 1", "msg 2" };

            using (var listener = new UdpMessageListener(listenerPort))
            {
                var count = 0;
                listener.Listen(actualMessage =>
                {
                    count++;
                    Assert.IsTrue(expectedMessages.Contains(actualMessage));
                    if (count >= 2)
                        AsyncAssert.Done();
                });

                using (var writer1 = new UdpMessageWriter(writer1Port))
                {
                    using (var writer2 = new UdpMessageWriter(writer2Port))
                    {
                        writer1.Write(expectedMessages[0], "localhost", listenerPort);
                        writer2.Write(expectedMessages[1], "localhost", listenerPort);

                        AsyncAssert.Wait(100);
                    }
                }
            }
        }

        [TestMethod]
        public void ShouldWriteMessagesToMultipleListeners()
        {
            var listener1Port = 20005;
            var listener2Port = 20006;
            var writerPort = 20007;

            var expectedMessages = new string[] { "msg 1", "msg 2" };

            using (var listener1 = new UdpMessageListener(listener1Port))
            {
                using (var listener2 = new UdpMessageListener(listener2Port))
                {
                    using (var writer = new UdpMessageWriter(writerPort))
                    {
                        var count = 0;
                        Action<string> messageHandler = actualMessage =>
                        {
                            count++;
                            Assert.IsTrue(expectedMessages.Contains(actualMessage));
                            if (count >= 2)
                                AsyncAssert.Done();
                        };

                        listener1.Listen(messageHandler);
                        listener2.Listen(messageHandler);

                        writer.Write(expectedMessages[0], "localhost", listener1Port);
                        writer.Write(expectedMessages[1], "localhost", listener2Port);

                        AsyncAssert.Wait(500);
                    }
                }
            }
        }
    }
}
