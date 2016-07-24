namespace GameCore.Commons

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

    //TODO: delete
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
            
        



            