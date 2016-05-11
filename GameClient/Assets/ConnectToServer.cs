using NetworkStuff;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ConnectToServer : MonoBehaviour
{
    public string Ip = "192.168.0.2";
    public int Port = 20010;

    void Start()
    {
        var client = Factory.CreateClient(8001,8002);
        client.InformYourListeningPortToHost(Ip,Port,MessageReceived);
        //client.SendMessage("Olá, mundo!");
        
    }
    string Mensagem = "";
    private void MessageReceived(string msg, Address address)
    {
        Debug.Log(msg);
        Mensagem = msg;
    }

    void OnGUI() {
        GUILayout.Label(Mensagem);
    }
}
