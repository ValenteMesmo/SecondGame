using Client;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Common
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class SandboxTests
    {
        [TestMethod]
        public void MyTestMethod()
        {
            new ClientWorld();
            
        }
    }
}
