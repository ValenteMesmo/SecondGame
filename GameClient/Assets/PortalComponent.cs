using System;
using Common.GameComponents;
using UnityEngine;
using NetworkStuff;

public class PortalComponent : MonoBehaviour
{
    private string Ip = "";

    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        //this is not right.... this gamecomponent should be created by a factory that subscribe  FoundNewIp
        WorldComponent.Sandbox.FoundNewIP.Subscribe(OnNewIPFound);
        WorldComponent.Sandbox.PlayerEnteredThePortal.Subscribe(OnPlayerEnteredThePortal);        
    }

    private void OnPlayerEnteredThePortal(MultiplayerPortal obj)
    {
        if (obj.Ip == Ip)
            GetComponent<SpriteRenderer>().enabled = false;
    }

    private void OnNewIPFound(string obj)
    {
        if (Ip == "")
        {
            Ip = obj;
            GetComponent<SpriteRenderer>().enabled = true;            
            WorldComponent.Sandbox.AddMultiplayerPortal.Publish(Ip);
        }
    }
}
