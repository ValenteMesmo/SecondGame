using UnityEngine;
using GameCore;
using System;

public class PlayerScript : MonoBehaviour
{
    IPlayer player;
    //ISetUserInputs input;

    void Start()
    {
        player = Factory.CreatePlayer();
        //input = Factory.GetInputSetter();
    }
    DateTime current = DateTime.Now;
    void Update()
    {
        //input.SetLeftPressed(Input.GetAxis("Horizontal") < 0);
        //input.SetRightPressed(Input.GetAxis("Horizontal") > 0);
        player.Update((current - DateTime.Now).Ticks);
        transform.position = new Vector2(player.GetX(), transform.position.y);
    }
}
