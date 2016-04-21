using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetworkStuff.Udp;
using System;

namespace NetworkStuff.Tests
{
    [TestClass]
    public class HandleMessageThreeTypesOfMessagesTest
    {
        [TestMethod]
        public void MessageStartingWithZeroShouldTriggerFirstCallback()
        {
            var message = "0andSomeOtherCharacters";

            bool a = false, b = false, c = false;

            var sut = new KnowWhichHandlerCallBasedOnMessagesType(
                msg => { a = true; },
                msg => { b = true; },
                msg => { c = true; });

            sut.Handle(message);

            Assert.IsTrue(a);
            Assert.IsFalse(b);
            Assert.IsFalse(c);
        }

        [TestMethod]
        public void MessageStartingWithZeroShouldTriggerSecondCallback()
        {
            var message = "1andSomeOtherCharacters";

            bool a = false, b = false, c = false;

            var sut = new KnowWhichHandlerCallBasedOnMessagesType(
                msg => { a = true; },
                msg => { b = true; },
                msg => { c = true; });

            sut.Handle(message);

            Assert.IsTrue(b);
            Assert.IsFalse(a);
            Assert.IsFalse(c);
        }

        [TestMethod]
        public void MessageStartingWithZeroShouldTriggerThirdCallback()
        {
            var message = "2andSomeOtherCharacters";

            bool a = false, b = false, c = false;

            var sut = new KnowWhichHandlerCallBasedOnMessagesType(
                msg => { a = true; },
                msg => { b = true; },
                msg => { c = true; });

            sut.Handle(message);

            Assert.IsTrue(c);
            Assert.IsFalse(a);
            Assert.IsFalse(b);
        }

        [TestMethod, ExpectedException(typeof(Exception))]
        public void EmptyMessageIsNotAllowed()
        {
            var message = string.Empty;

            var sut = new KnowWhichHandlerCallBasedOnMessagesType(
                msg => { },
                msg => { },
                msg => { });

            sut.Handle(message);
        }

        [TestMethod, ExpectedException(typeof(Exception))]
        public void AcceptOnlyZeroOneOrTwoAsFirstCaracter()
        {
            var message = "3andSomeOtherCharacters";

            var sut = new KnowWhichHandlerCallBasedOnMessagesType(
                msg => { },
                msg => { },
                msg => { });

            sut.Handle(message);
        }
    }
}
