using UnityEngine;
using NetworkStuff;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConnectToHostButtonHandler : MonoBehaviour
{
    public InputField Ip;
    public InputField Port;

    public void ConnectToHost()
    {
        try
        {
            ConnectionKeeper.Connect(Ip.text,int.Parse(Port.text));
            SceneManager.LoadScene("ChatAsClient");
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
    }
}

public static class ConnectionKeeper {
    private static Client Client;
    public static Action<string> onMessageReceived = msg => { };


    public static void Listen(Action <string> handler)
    {
        if (handler == null)
            throw new ArgumentNullException("Action to call on message received event.");
        onMessageReceived = handler;
    }

    public static void Connect(string ip, int port) {
        Client = Factory.CreateClient(8001, 8002);
        Client.InformYourListeningPortToHost(ip, port, MessageReceived);
    }

    private static void MessageReceived(string message, Address address)
    {
        onMessageReceived(message);
    }
}
