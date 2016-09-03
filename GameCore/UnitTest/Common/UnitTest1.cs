using System;
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
    }
}
//namespace UnitTests

//open System
//open GameCore.Commons
//open Microsoft.VisualStudio.TestTools.UnitTesting

//[< TestClass >]
//type TestsSample() =

//    [<TestMethod>]
//member this.GetCombinations() =

//        let Items = ["A"; "B"; "C"; "D"]

//let expected = ["CD"; "BC"; "BD"; "AB"; "AC"; "AD"]
//let mutable actual : string list = []

//let combinations = Items |> xxx.GetCombinations

//        for combination in combinations do
//            let x, y =  combination
//            actual <- x + y :: actual

//        Assert.AreEqual(6, actual.Length);
//Assert.AreEqual(expected.Item 0, actual.Item 0);
//Assert.AreEqual(expected.Item 1, actual.Item 1);
//Assert.AreEqual(expected.Item 2, actual.Item 2);
//Assert.AreEqual(expected.Item 3, actual.Item 3);
//Assert.AreEqual(expected.Item 4, actual.Item 4);
//Assert.AreEqual(expected.Item 5, actual.Item 5);

//[<TestMethod>]
//member this.ForeachCombination() =

//        let Items = ["A"; "B"; "C"; "D"]

//let expected = ["CD"; "BC"; "BD"; "AB"; "AC"; "AD"]
//let mutable actual : string list = []
//let handler x y =
//            actual <- x + y :: actual
//            true

//        Items |> xxx.ForEachCombination <| handler

//        Assert.AreEqual(6, actual.Length);
//Assert.AreEqual(expected.Item 0, actual.Item 0);
//Assert.AreEqual(expected.Item 1, actual.Item 1);
//Assert.AreEqual(expected.Item 2, actual.Item 2);
//Assert.AreEqual(expected.Item 3, actual.Item 3);
//Assert.AreEqual(expected.Item 4, actual.Item 4);
//Assert.AreEqual(expected.Item 5, actual.Item 5);