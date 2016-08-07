module PlayerOneInput
    let mutable private leftDown = false
    let mutable private punchDown = false
    let mutable private rightDown = false
    let SetLeft value =  leftDown <- value        
    let SetRight value = rightDown <- value        
    let SetPunch value = punchDown <- value        
    let GetLeft () = leftDown
    let GetRight () = rightDown
    let GetPunch () = punchDown