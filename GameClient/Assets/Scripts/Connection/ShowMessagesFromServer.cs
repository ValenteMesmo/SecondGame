using UnityEngine;
using UnityEngine.UI;
using System;

public class ShowMessagesFromServer : MonoBehaviour
{
    public Text messageDisplay;

    void Start()
    {
        if (messageDisplay == null)
            throw new ArgumentNullException(
                "Reference to a messageDisplay must be set on Editor");
        ConnectionKeeper.Listen(MessageReceived);
    }

    string messageHistory = "";
    private void MessageReceived(string msg)
    {
        Debug.Log(msg);
        messageHistory = msg + Environment.NewLine+ messageHistory;
    }

    void Update() {
        messageDisplay.text = messageHistory;
    }
}
