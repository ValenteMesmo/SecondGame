namespace GameCore.Commons
open System

type Collider() = 
    let mutable x = 0.0f
    let mutable y = 0.0f
    let mutable width = 0.0f
    let mutable height = 0.0f
    //todo: allow set:
    member this.OnCollision (a : Collider) (b: Collider) = true
    member this.X 
        with get() = x 
        and set(value) = x <- value    
    member this.Y 
        with get() = y 
        and set(value) = y <- value
    member this.Width
        with get() = width
        and set(value) = width <- value
    member this.Height
        with get() = height
        and set(value) = height <- value
//first comes updates then comes the collision handlers

module xxx =
    let UpdateEverything updates = 
        for update in updates do
            update()

    let ForEachCombination<'T> (list : 'T list) (action : 'T -> 'T -> bool) =
        for i in 0 .. list.Length - 1 do
            let mutable j = list.Length - 1
            while j > i do
                action (list.Item i) (list.Item j) |> ignore
                j <- j - 1

    [<Obsolete "I dont know if this method has a good performance... use ForeachCombination">]
    let GetCombinations<'T> (list : 'T list) =
        [for i in 0 .. list.Length - 1 do
            let mutable j = list.Length - 1
            while j > i do
                yield (list.Item i, list.Item j)
                j <- j - 1]

    let handleSingleCollision (a : Collider) (b : Collider) =
        if a.X + a.Width < b.X
        || b.X + b.Width < a.X
        || a.Y + a.Height < b.Y
        || b.Y + b.Height < a.Y 
            then 
                false
            else
                a.OnCollision a b |> ignore
                b.OnCollision b a |> ignore
                true

    let HandleAllCollisions colliders =
        colliders |> ForEachCombination <| handleSingleCollision

    let private speed = 0.2f

    let mutable updatedAt = DateTime.Now

    let private UpdateHorizontalPosition (collider : Collider) =        
        let millisecondsSinceLastUpdate = float32((DateTime.Now - updatedAt).Milliseconds)
        
        if PlayerOneInput.GetLeft() then
            collider.X <- collider.X - speed * (millisecondsSinceLastUpdate / 100.0f)
        else if PlayerOneInput.GetRight() then
            collider.X <- collider.X + speed * (millisecondsSinceLastUpdate / 100.0f)        
            
        updatedAt <- DateTime.Now
        true

    let private updatePlayerArmPosition (playerCollider : Collider) (armCollider : Collider) =
        if PlayerOneInput.GetPunch() then
            armCollider.X <- playerCollider.X + 0.6f
        else
            armCollider.X <- playerCollider.X

    let playerUpdate collider armCollider = 
        UpdateHorizontalPosition collider |> ignore
        updatePlayerArmPosition collider armCollider