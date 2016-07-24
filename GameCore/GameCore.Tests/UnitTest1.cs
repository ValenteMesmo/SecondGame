using GameCore.Updatables;
using GameCore.Commons;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Core;

namespace GameCore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldAccelerateToTheLeft()
        {
            var collider = new Collider();
            var sut = new MovementController(collider, 1);

            sut.SpeedUpToTheLeft();
            Assert.AreEqual(-1, collider.X);

            sut.SpeedUpToTheLeft();
            Assert.AreEqual(-3, collider.X);

            sut.SpeedUpToTheLeft();
            Assert.AreEqual(-6, collider.X);

            sut.SpeedUpToTheLeft();
            Assert.AreEqual(-10, collider.X);

            sut.SpeedUpToTheLeft();
            Assert.AreEqual(-15, collider.X);

            sut.SpeedUpToTheLeft();
            Assert.AreEqual(-21, collider.X);

            sut.SpeedUpToTheLeft();
            Assert.AreEqual(-28, collider.X);

            sut.SpeedUpToTheLeft();
            Assert.AreEqual(-36, collider.X);
        }

        [TestMethod]
        public void ShouldAccelerateToTheRight()
        {
            var collider = new Collider();
            var sut = new MovementController(collider, 1);

            sut.SpeedUpToTheRight();
            Assert.AreEqual(1, collider.X);

            sut.SpeedUpToTheRight();
            Assert.AreEqual(3, collider.X);

            sut.SpeedUpToTheRight();
            Assert.AreEqual(6, collider.X);

            sut.SpeedUpToTheRight();
            Assert.AreEqual(10, collider.X);

            sut.SpeedUpToTheRight();
            Assert.AreEqual(15, collider.X);

            sut.SpeedUpToTheRight();
            Assert.AreEqual(21, collider.X);

            sut.SpeedUpToTheRight();
            Assert.AreEqual(28, collider.X);

            sut.SpeedUpToTheRight();
            Assert.AreEqual(36, collider.X);
        }

        [TestMethod]
        public void SlowDownShouldStopMovementToTheRight()
        {
            var collider = new Collider();
            var sut = new MovementController(collider, 1);

            sut.SpeedUpToTheRight();
            sut.SpeedUpToTheRight();
            sut.SpeedUpToTheRight();
            sut.SpeedUpToTheRight();
            Assert.AreEqual(10, collider.X);
            sut.SlowDown();
            Assert.AreEqual(13, collider.X);
            sut.SlowDown();
            Assert.AreEqual(15, collider.X);
            sut.SlowDown();
            Assert.AreEqual(16, collider.X);
            sut.SlowDown();
            Assert.AreEqual(16, collider.X);
            sut.SlowDown();
            Assert.AreEqual(16, collider.X);
        }

        [TestMethod]
        public void SlowDownShouldStopMovementToTheLeft()
        {
            var collider = new Collider();
            var sut = new MovementController(collider, 1);

            sut.SpeedUpToTheLeft();
            sut.SpeedUpToTheLeft();
            sut.SpeedUpToTheLeft();
            sut.SpeedUpToTheLeft();
            Assert.AreEqual(-10, collider.X);
            sut.SlowDown(); 
            Assert.AreEqual(-13, collider.X);
            sut.SlowDown(); 
            Assert.AreEqual(-15, collider.X);
            sut.SlowDown(); 
            Assert.AreEqual(-16, collider.X);
            sut.SlowDown(); 
            Assert.AreEqual(-16, collider.X);
            sut.SlowDown(); 
            Assert.AreEqual(-16, collider.X);
        }

        [TestMethod]
        public void NothingSetAlreadyColliding()
        {
            var first = new Collider { };
            var second = new Collider { };

            var actual = xxx.handleSingleCollision(first, second);

            Assert.IsTrue(actual, "Collision not detected!");
        }

        [TestMethod]
        public void SimpleCollisionExample()
        {
            var first = new Collider { X = 10 };
            var second = new Collider { X = 0 };

            var actual = xxx.handleSingleCollision(first, second);
            Assert.IsFalse(actual, "Collision detected!");

            new MovementController(second, 10).SpeedUpToTheRight();
            actual = xxx.handleSingleCollision(first, second);
            Assert.IsTrue(actual, "Collision not detected!");
        }

        //[TestMethod]
        //public void ForEachCombination()
        //{
        //    var sut = new List<string> {
        //        "A", "B", "C", "D"
        //    };

        //    var actual = new FSharpList<string>(null,null);
        //    xxx.ForEachCombination(sut, (first, second) =>
        //    {
        //        actual.Add(first + second);
        //        return new Unit();
        //    });

        //    Assert.AreEqual(6, actual.Count);
        //    Assert.AreEqual("AD", actual[0]);
        //    Assert.AreEqual("AC", actual[1]);
        //    Assert.AreEqual("AB", actual[2]);
        //    Assert.AreEqual("BD", actual[3]);
        //    Assert.AreEqual("BC", actual[4]);
        //    Assert.AreEqual("CD", actual[5]);
        //}
    }
}
