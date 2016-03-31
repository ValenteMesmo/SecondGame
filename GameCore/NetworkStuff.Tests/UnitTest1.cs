using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetworkStuff.Udp;
using System;

namespace NetworkStuff.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldReceiveAtLeastMessage()
        {
            var listenerPort = 20000;
            var writerPort = 20001;
            var expectedMessage = "Opa! excelente~";

            var listener = new UdpMessageListener(listenerPort);
            var writer = new UdpMessageWriter(writerPort);

            listener.Listen(actualMessage =>
            {
                Assert.AreEqual(expectedMessage, actualMessage);
                AsyncAssert.Done();
            });

            writer.Write(expectedMessage, "localhost", listenerPort);

            AsyncAssert.Wait();

            listener.Dispose();
            writer.Dispose();
        }

        [TestMethod]
        public void ShouldReceiveMessagesFromMultipleSources()
        {
            var listenerPort = 20000;
            var writer1Port = 20001;
            var writer2Port = 20002;

            var expectedMessages = new string[] { "msg 1", "msg 2" };

            var listener = new UdpMessageListener(listenerPort);

            var writer1 = new UdpMessageWriter(writer1Port);
            var writer2 = new UdpMessageWriter(writer2Port);

            var count = 0;
            listener.Listen(actualMessage =>
            {
                count++;
                Assert.IsTrue(expectedMessages.Contains(actualMessage));
                if (count >= 2)
                    AsyncAssert.Done();
            });

            writer1.Write(expectedMessages[0], "localhost", listenerPort);
            writer2.Write(expectedMessages[1], "localhost", listenerPort);

            AsyncAssert.Wait();

            listener.Dispose();
            writer1.Dispose();
            writer2.Dispose();
        }

        [TestMethod]
        public void ShouldWriteMessagesToMultipleListeners()
        {
            var listener1Port = 20000;
            var listener2Port = 20001;
            var writerPort = 20002;

            var expectedMessages = new string[] { "msg 1", "msg 2" };

            var listener1 = new UdpMessageListener(listener1Port);
            var listener2 = new UdpMessageListener(listener2Port);

            var writer = new UdpMessageWriter(writerPort);

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

            AsyncAssert.Wait(200);

            listener1.Dispose();
            listener2.Dispose();
            writer.Dispose();
        }
    }
}
