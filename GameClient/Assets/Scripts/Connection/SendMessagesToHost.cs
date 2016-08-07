using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class SendMessagesToHost : MonoBehaviour
{
    public InputField messageInput;

    void Start()
    {
        if (messageInput == null)
            throw new ArgumentNullException(
                "Reference to a messageInput must be set on Editor");
        ConnectionKeeper.Connect();
    }


    public void SendMessageToHost(string message)
    {
        messageInput.text = string.Empty;
        ConnectionKeeper.SendMessage(message);
    }

}
