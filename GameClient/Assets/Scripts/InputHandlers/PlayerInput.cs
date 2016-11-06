using UnityEngine;
using System;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
    //public void DelayExecution(Action action, float delayInSeconds)
    //{
    //    StartCoroutine(DelayedAction(action, delayInSeconds));
    //}

    //private IEnumerator DelayedAction(Action action, float seconds)
    //{
    //    yield return new WaitForSeconds(seconds);
    //    action();
    //}

    public void Update()
    {
#if !UNITY_ANDROID || UNITY_EDITOR
        var axis_h = Input.GetAxis("Horizontal");

        WorldComponent.Sandbox.RightPressed.Publish(axis_h > 0);
        WorldComponent.Sandbox.LeftPressed.Publish(axis_h < 0);
        WorldComponent.Sandbox.UpPressed.Publish(Input.GetKey(KeyCode.Space));
#endif
#if UNITY_EDITOR
        WorldComponent.Sandbox.UpPressed.Publish(Input.GetButton("Jump"));
#endif
    }
}