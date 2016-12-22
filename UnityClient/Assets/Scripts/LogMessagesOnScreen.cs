using UnityEngine;
using System;
using System.Collections.Generic;

public class LogMessagesOnScreen : MonoBehaviour
{
//#if UNITY_EDITOR
    string messageOnScreen = "";
    List<string> messages = new List<string>();

    void Awake()
    {
        Application.logMessageReceived += Application_logMessageReceived;
        //WorldComponent.Sandbox.OtherPlayerPositionChanged.Subscribe(pos => Debug.Log(pos.X));
        //WorldComponent.Sandbox.ClinetEvents_OtherPlayerAdded.Subscribe(na => Debug.Log(na));
        WorldComponent.Sandbox.Log.Subscribe(msg =>
        {
            Debug.Log(msg);
        });
    }

    private void Application_logMessageReceived(string condition, string stackTrace, LogType type)
    {
        messages.Add(condition);
        if (messages.Count > 40)
            messages.RemoveAt(0);

        messageOnScreen = "";
        foreach (var item in messages)
        {
            messageOnScreen = item + Environment.NewLine + messageOnScreen;
        }
    }

    void OnGUI()
    {
        GUILayout.TextField(messageOnScreen);
    } 
//#endif
}