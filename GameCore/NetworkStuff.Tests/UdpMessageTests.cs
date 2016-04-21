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
            var writerPort = 20001;
            var expectedMessage = "Opa! excelente~";

            var listener = new UdpMessageListener(listenerPort);
            listener.Listen((actualMessage, Endpoint) =>
            {
                Assert.AreEqual(expectedMessage, actualMessage);
                AsyncAssert.Done();
            });

            var writer = new UdpMessageWriter(writerPort);
            writer.Write(expectedMessage, "localhost", listenerPort);

            AsyncAssert.Wait();

            writer.Dispose();
            listener.Dispose();
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
                listener.Listen((actualMessage, endpoint) =>
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

                        AsyncAssert.Wait();
                    }
                }
            }
        }

        ////TODO: Damn it! this test fails sometimes
        //[TestMethod]
        //public void ShouldBroadcastMessages()
        //{
        //    var listener1Port = 20000;
        //    var listener2Port = 20001;
        //    var writerPort = 20002;
        //    var expectedMessage = "Opa! excelente~";

        //    using (var listener1 = new UdpMessageListener(listener1Port))
        //    {
        //        using (var listener2 = new UdpMessageListener(listener2Port))
        //        {
        //            using (var broadcaster = new UdpMessageWriter(writerPort))
        //            {
        //                var count = 0;

        //                Action<string, Address> handler = (actualMessage, endpoint) =>
        //                 {
        //                     count++;
        //                     Assert.AreEqual(expectedMessage, actualMessage);
        //                     if (count >= 2)
        //                         AsyncAssert.Done();
        //                 };

        //                listener1.Listen(handler);
        //                listener2.Listen(handler);

        //                broadcaster.Write(expectedMessage, "localhost", listener1Port);
        //                broadcaster.Write(expectedMessage, "localhost", listener2Port);

        //                AsyncAssert.Wait();
        //            }
        //        }
        //    }
        //}
    }
}
