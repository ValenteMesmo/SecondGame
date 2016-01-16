using UnityEngine;
using System.Collections;

public class ConnectToServer : MonoBehaviour
{
    public string Ip = "192.168.0.8";
    public int Port = 8001;
    private ClientClass client;
    public GameLoop game;

    void Start()
    {
        client = new ClientClass(Ip, Port);
        client.Start(OnMessageReceivedFromServer);
    }

    private void OnMessageReceivedFromServer(string msg)
    {
        
        var asdsa = msg.Split('|');
        //game.World.//
    }

    void OnDestroy()
    {
        client.Dispose();
    }
}
