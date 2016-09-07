using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ForEachCombination()
        {
            var items = new List<string> { "A", "B", "C", "D" };

            var expected = new List<string> {
                "AD",
                "AC",
                "AB",
                "BD",
                "BC",
                "CD",
            };

            var actual = new List<string>();

            items.ForEachCombination(
                (a, b) => { actual.Add(a + b); });

            Assert.AreEqual(6, actual.Count);
            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
            Assert.AreEqual(expected[2], actual[2]);
            Assert.AreEqual(expected[3], actual[3]);
            Assert.AreEqual(expected[4], actual[4]);
            Assert.AreEqual(expected[5], actual[5]);
        }

        [TestMethod]
        public void ForEachCombination1()
        {
            var items = new List<string> { "A" };

            var actual = new List<string>();

            items.ForEachCombination(
                (a, b) => { actual.Add(a + b); });

            Assert.AreEqual(0, actual.Count);
        }

        [TestMethod]
        public void LeftConllision()
        {
            var sut = new List<Collider>();
            var result1 = false;
            var result2 = false;
            sut.Add(new Collider
            {
                Height = 1,
                Width = 1,
                X = 0f,
                OnLeftCollision = _ => result1 = false,
                OnRightCollision = _ => result1 = true,
                OnTopCollision = _ => result1 = false,
                OnBotCollision = _ => result1 = false
            });
            sut.Add(new Collider
            {
                Height = 1,
                Width = 1,
                X = 0.5f,
                OnLeftCollision = _ => result2 = true,
                OnRightCollision = _ => result2 = false,
                OnTopCollision = _ => result2 = false,
                OnBotCollision = _ => result2 = false
            });

            sut.HandleCollisions();
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void RightConllision()
        {
            var sut = new List<Collider>();
            var result1 = false;
            var result2 = false;
            sut.Add(new Collider
            {
                Height = 1,
                Width = 1,
                X = 0f,
                OnLeftCollision = _ => result1 = true,
                OnRightCollision = _ => result1 = false,
                OnTopCollision = _ => result1 = false,
                OnBotCollision = _ => result1 = false
            });
            sut.Add(new Collider
            {
                Height = 1,
                Width = 1,
                X = -0.5f,
                OnLeftCollision = _ => result2 = false,
                OnRightCollision = _ => result2 = true,
                OnTopCollision = _ => result2 = false,
                OnBotCollision = _ => result2 = false
            });

            sut.HandleCollisions();
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void BotConllision()
        {
            var sut = new List<Collider>();
            var result1 = false;
            var result2 = false;
            sut.Add(new Collider
            {
                Height = 1,
                Width = 1,
                OnBotCollision = _ =>
                {
                    result1 = true;
                }
            });
            sut.Add(new Collider
            {
                Height = 1,
                Width = 1,
                Y = -0.5f,
                OnTopCollision = _ =>
                {
                    result2 = true;
                }
            });

            sut.HandleCollisions();
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void TopConllision()
        {
            var sut = new List<Collider>();
            var result1 = false;
            var result2 = false;
            sut.Add(new Collider
            {
                Height = 1,
                Width = 1,
                OnTopCollision = _ =>
                {
                    result1 = true;
                }
            });
            sut.Add(new Collider
            {
                Height = 1,
                Width = 1,
                Y = 0.5f,
                OnBotCollision = _ =>
                {
                    result2 = true;
                }
            });

            sut.HandleCollisions();
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
        }
    }
}