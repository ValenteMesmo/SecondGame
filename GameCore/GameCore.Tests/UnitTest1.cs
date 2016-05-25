using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GameCore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void NothingSetAlreadyColliding()
        {
            var sut = new CollisionDetector();

            var first = new Collider { };
            var second = new Collider { };

            var actual = sut.IsColliding(first, second);

            Assert.IsTrue(actual, "Collision not detected!");
        }

        [TestMethod]
        public void ForEachCombination()
        {
            var sut = new List<string> {
                "A", "B", "C", "D"
            };

            var actual = new List<string>();
            sut.ForEachCombination((first, second) =>
            {
                actual.Add(first + second);
            });

            Assert.AreEqual(6, actual.Count);
            Assert.AreEqual("AD", actual[0]);
            Assert.AreEqual("AC", actual[1]);
            Assert.AreEqual("AB", actual[2]);
            Assert.AreEqual("BD", actual[3]);
            Assert.AreEqual("BC", actual[4]);
            Assert.AreEqual("CD", actual[5]);
        }
    }
}
