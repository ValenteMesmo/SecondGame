﻿using UnityEngine;

public class ConnectToServer : MonoBehaviour
{  

    void Start()
    {
        ConnectionKeeper.Listen(MessageReceived);
    }

    string Mensagem = "";
    private void MessageReceived(string msg)
    {
        Debug.Log(msg);
        Mensagem = msg;
    }

    void OnGUI() {
        GUILayout.Label(Mensagem);
    }
}
