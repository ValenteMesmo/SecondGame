using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameCore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void NothingSetAlreadyColliding()
        {
            var sut = new DetectsCollision();

            var first = new Collider { };
            var second = new Collider { };

            var actual = sut.IsColliding(first, second);

            Assert.IsTrue(actual, "Collision not detected!");
        }
    }
}
