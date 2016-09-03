using UnityEngine;
using System;
using System.Collections;
using Common;

public class PlayerInput : MonoBehaviour
{
    public void DelayExecution(Action action, float delayInSeconds)
    {
        StartCoroutine(DelayedAction(action, delayInSeconds));
    }

    private IEnumerator DelayedAction(Action action, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        action();
    }

    public void Update()
    {
        var axis_h = Input.GetAxis("Horizontal");        
        Player1Input.RightIsPressed = axis_h > 0;
        Player1Input.LeftIsPressed  = axis_h < 0;
        Player1Input.PunchPressed = Input.GetKey(KeyCode.Space);
    }
}