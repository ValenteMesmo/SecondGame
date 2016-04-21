using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetworkStuff.Udp;

namespace NetworkStuff.Tests
{
    [TestClass]
    public class GetListenerAdressFromMessageTests
    {
        [TestMethod]
        public void ShouldExtractTheListenersAddressFromWritersMessage()
        {
            var sut = new GetListenerAdressFromMessage();
            var writersOrigin = new Address("127.0.0.1", 20000);

            var listenersAdress = sut.Get(
                "0127.0.0.1:20001",
                writersOrigin);

            Assert.AreEqual(writersOrigin.Ip, listenersAdress.Ip);
            Assert.AreEqual(20001, listenersAdress.Port);
        }
    }
}
