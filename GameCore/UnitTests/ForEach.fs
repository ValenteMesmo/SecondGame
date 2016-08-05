namespace UnitTests

open System
open GameCore.Commons
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type TestsSample() =

    [<TestMethod>]
    member this.BlockShouldMoveOnUpdate() =
        xxx.updatedAt <- DateTime.Now

        Assert.IsTrue(new Collider() |> xxx.UpdateHorizontalPosition)

    [<TestMethod>]
    member this.BlockShouldMoveWhenRightKeyIsPressed() =
        xxx.updatedAt <- DateTime.Now

        let handleMovementToTheRight =
            if true then
                new Collider() |> xxx.UpdateHorizontalPosition 
            else
                false

        Assert.IsTrue(handleMovementToTheRight)

    [<TestMethod>]
    member this.GetCombinations() =
                
        let Items = ["A"; "B"; "C"; "D"]

        let expected = ["CD"; "BC"; "BD"; "AB"; "AC"; "AD"]
        let mutable actual : string list = []
        
        let combinations = Items |> xxx.GetCombinations
        
        for combination in combinations do
            let x, y =  combination
            actual <- x + y :: actual            

        Assert.AreEqual(6, actual.Length);
        Assert.AreEqual(expected.Item 0, actual.Item 0);
        Assert.AreEqual(expected.Item 1, actual.Item 1);
        Assert.AreEqual(expected.Item 2, actual.Item 2);
        Assert.AreEqual(expected.Item 3, actual.Item 3);
        Assert.AreEqual(expected.Item 4, actual.Item 4);
        Assert.AreEqual(expected.Item 5, actual.Item 5);
    
    [<TestMethod>]
    member this.ForeachCombination() =
            
        let Items = ["A"; "B"; "C"; "D"]

        let expected = ["CD"; "BC"; "BD"; "AB"; "AC"; "AD"]
        let mutable actual : string list = []
        let handler x y =
            actual <- x + y :: actual
            true
        
        Items |> xxx.ForEachCombination <| handler
        
        Assert.AreEqual(6, actual.Length);
        Assert.AreEqual(expected.Item 0, actual.Item 0);
        Assert.AreEqual(expected.Item 1, actual.Item 1);
        Assert.AreEqual(expected.Item 2, actual.Item 2);
        Assert.AreEqual(expected.Item 3, actual.Item 3);
        Assert.AreEqual(expected.Item 4, actual.Item 4);
        Assert.AreEqual(expected.Item 5, actual.Item 5);