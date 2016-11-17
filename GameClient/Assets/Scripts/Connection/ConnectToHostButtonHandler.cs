using UnityEngine;
using NetworkStuff;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class ConnectToHostButtonHandler : MonoBehaviour
{
    public InputField Ip;
    public InputField Port;

    public void ConnectToHost()
    {
        try
        {
            ConnectionKeeper.Ip = Ip.text;
            ConnectionKeeper.Port = int.Parse(Port.text);
            SceneManager.LoadScene("ChatAsClient");
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
    }
}

public static class ConnectionKeeper
{
    public static string Ip;
    public static int Port;

    private static Client Client;
    public static Action<string> onMessageReceived = msg => { };

    public static void Listen(Action<string> handler)
    {
        if (handler == null)
            throw new ArgumentNullException("Action to call on message received event.");
        onMessageReceived = handler;
    }

    public static void Connect()
    {
        //TODO validate ip and port
        Client = Factory.CreateClient(8001, 8002);
        Client.Listen(Ip, Port, MessageReceived);
    }

    public static void SendMessage(string message)
    {
        Client.SendMessage(message);
    }

    private static void MessageReceived(string message, Address address)
    {
        onMessageReceived(message);
    }
}
