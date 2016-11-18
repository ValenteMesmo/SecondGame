using UnityEngine;
using NetworkStuff;
using UnityEngine.UI;
using System;

public class MessageBroadCaster : MonoBehaviour
{
    Host host;

    public Text IpAndPortDisplay;
    public Text MessageDisplay;
    public InputField InputField;

    void Start()
    {
        if (InputField == null)
            throw new ArgumentNullException("No reference was set to InputField on Editor");
        if (IpAndPortDisplay == null)
            throw new ArgumentNullException("No reference was set to IpAndPortDisplay on Editor");
        if (MessageDisplay == null)
            throw new ArgumentNullException("No reference was set to MessageDisplay on Editor");

        host = Factory.CreateHost(8002);

        host.Listen(MessageReceived);
    }

    void Update()
    {
        //IpAndPortDisplay.text = HostAddress;
        MessageDisplay.text = MessageHistory;
    }

    string MessageHistory = "";
    private void MessageReceived(string message, Address address)
    {
        MessageHistory = message + Environment.NewLine + MessageHistory;
    }

    public void SendMessageToClients(string message)
    {
        if (string.IsNullOrEmpty(message))
            return;

        InputField.text = string.Empty;
        MessageHistory = message + Environment.NewLine + MessageHistory;
        host.SendMessage(message);
    }
}
