using UnityEngine;
using GameCore;
using System;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
    public void SetLeft()
    {
        PlayerOneInput.SetLeft(true);
        DelayExecution(() => PlayerOneInput.SetLeft(false), 0.5f);
    }

    public void SetRight()
    {
        PlayerOneInput.SetRight(true);
        DelayExecution(() => PlayerOneInput.SetRight(false), 0.5f);
    }

    public void DelayExecution(Action action, float delayInSeconds)
    {
        StartCoroutine(DelayedAction(action, delayInSeconds));
    }

    private IEnumerator DelayedAction(Action action, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        action();
    }
}
