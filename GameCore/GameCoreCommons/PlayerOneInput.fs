module PlayerOneInput
    let mutable private leftDown = false
    let mutable private rightDown = false
    let SetLeft value = 
        leftDown <- value        
    let SetRight value = 
        rightDown <- value        
    let GetLeft () = leftDown
    let GetRight () = rightDown