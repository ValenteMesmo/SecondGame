using UnityEngine;
using System.Collections;
using NetworkStuff;

public class MessageBroadCaster : MonoBehaviour {

    public string Ip = "192.168.0.2";
    public int Port = 20010;
    string Mensagem = "";
    void Start()
    {
        var host = Factory.CreateHost(8001, 8002);        
        Mensagem = host.Ip+":"+host.Port;
        Debug.Log(Mensagem);
    }

    void OnGUI()
    {
        GUILayout.Label(Mensagem);
    }
}
