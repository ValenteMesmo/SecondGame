using UnityEngine;
using GameCore;
using System;
using GameCore.Commons;

public class PlayerScript : MonoBehaviour
{
    GameCore.Commons.Collider myCollider = new GameCore.Commons.Collider();

    void Update()
    {   
        xxx.UpdateHorizontalPosition(myCollider);
        transform.position = new Vector2(myCollider.X, transform.position.y);
    }
}
