using UnityEngine;
using System.Collections;
using System;

public class LogMessagesOnScreen : MonoBehaviour
{
    string message = "";

    void Awake()
    {
        Application.logMessageReceived += Application_logMessageReceived;
        Debug.Log("teste");
    }

    private void Application_logMessageReceived(string condition, string stackTrace, LogType type)
    {
        message = condition + Environment.NewLine + message;
    }

    void OnGUI()
    {
        GUILayout.TextField(message);
    }
}
