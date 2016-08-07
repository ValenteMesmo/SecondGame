﻿using UnityEngine;
using GameCore;
using System;
using GameCore.Commons;
using System.Collections.Generic;
using Microsoft.FSharp.Core;

public class PlayerScript : MonoBehaviour
{
    GameCore.Commons.Collider myCollider = new GameCore.Commons.Collider();
    GameCore.Commons.Collider armCollider = new GameCore.Commons.Collider();

    public Transform armTransform;

    void Update()
    {
        xxx.playerUpdate(myCollider, armCollider);
        transform.position = new Vector2(myCollider.X, transform.position.y);
        armTransform.position = new Vector2(armCollider.X, armCollider.Y);
        //xxx.HandleAllCollisions(new List<GameCore.Commons.Collider>());

        World.AddCollider(f => { });
    }
}
