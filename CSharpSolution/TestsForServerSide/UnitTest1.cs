using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientSide;
using System.Threading;

namespace TestsForServerSide
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ThingUpdatedCallbackShouldBeCalled()
        {
            var ok = false;

            var client = new GameClient(f =>
            {
                ok = true;
            });

            Thread.Sleep(10);

            Assert.IsTrue(ok);

            client.Dispose();
        }
    }
}
