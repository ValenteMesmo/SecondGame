namespace GameCore.Commons
open GameCore.Commons
open System
open Microsoft.FSharp.Collections
open System.Collections.Generic

module World =
    let private updates = []
    let AddUpdate update =
        updates = update :: updates

    //TODO: replace dictionary with tuple
    let private colliders = new Dictionary<Collider, Action<Collider>>()
    let AddCollider onColliderChanged =
        colliders.Add(new Collider(), onColliderChanged)

    let mutable private updatedAt = DateTime.Now
    let Update =
        for update in updates do update
        xxx.HandleAllCollisions (List.ofSeq colliders.Keys) //TODO: where will the callbacks come from?
        //today, they come from a collider prop

        for item in colliders do
            item.Value.Invoke item.Key

        updatedAt <- DateTime.Now  
