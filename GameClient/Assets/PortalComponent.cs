using System;
using Common.GameComponents;
using UnityEngine;
using NetworkStuff;

public class PortalComponent : MonoBehaviour
{
    private string Ip = "";
    private bool portalVisible = false;

    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        //this is not right.... this gamecomponent should be created by a factory that subscribe  FoundNewIp
        WorldComponent.Sandbox.FoundNewIP.Subscribe(OnNewIPFound);
        WorldComponent.Sandbox.PlayerEnteredThePortal.Subscribe(OnPlayerEnteredThePortal);
    }

    void Update()
    {
        GetComponent<SpriteRenderer>().enabled = portalVisible;
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
            portalVisible = true;
            Ip = obj;

            WorldComponent.Sandbox.AddMultiplayerPortal.Publish(Ip);
        }
    }
}
