using UnityEngine;
using GameCore;
using System;
using GameCore.Commons;

public class PlayerScript : MonoBehaviour
{
    IPlayer player;

    public float x_limit = 50;

    public string name2 = "";

    void Start()
    {
        name2 = new MyFsharpClass().X;
        player = Factory.CreatePlayer();
    }
    DateTime current = DateTime.Now;
    void Update()
    {
        player.Update((current - DateTime.Now).Ticks);

        var x = player.GetX();
        //if (x > x_limit)
        //    x = x_limit;
        //if (x < -x_limit)
        //    x = -x_limit;

        transform.position = new Vector2(x, transform.position.y);
    }
}
