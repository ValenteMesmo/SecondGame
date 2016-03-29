using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetworkStuff.Udp;

namespace NetworkStuff.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
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
    }
}
