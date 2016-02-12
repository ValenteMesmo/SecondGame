using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace TestsForCore
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var sut = new World();
            sut.AddThing(new Thing(""));

            var called = false;
            sut.SetActionToBeCalledWhenSomethingChanges(f=> {
                called = true;
            });

            Thread.Sleep(20);

            Assert.IsTrue(called);

            sut.Dispose();
        }
    }
}
