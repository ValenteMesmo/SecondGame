using UnityEngine;
using System;
using System.Collections.Generic;

public class LogMessagesOnScreen : MonoBehaviour
{
    string messageOnScreen = "";
    List<string> messages = new List<string>();

    void Awake()
    {
        Application.logMessageReceived += Application_logMessageReceived;
        Debug.Log("teste");        
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
}