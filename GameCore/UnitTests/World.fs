namespace UnitTests

open System
open GameCore.Commons
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type WorldTests() =

    [<TestMethod>]
    member this.GetCombinations() =

        World.AddCollider (new Collider()) |> ignore
        World.AddCollider (new Collider()) |> ignore