using UnityEngine;
using System.Collections;
using System;
using Common;

public class GameObjectFactory : MonoBehaviour
{
    private bool portalOn = false;
    private UnityEngine.GameObject portal;

    void Start()
    {
        WorldComponent.Sandbox.PortalCreated.Subscribe(PortalCreated);        
        WorldComponent.Sandbox.GuestPosiitonUpdate.Subscribe(UpdateGuest);
        WorldComponent.Sandbox.HostPosiitonUpdate.Subscribe(UpdateHost);
    }

    private void UpdateHost(Common.Collider obj)
    {
        Debug.Log("UpdateHost");
    }

    private void UpdateGuest(Common.Collider obj)
    {
        Debug.Log("UpdateGuest");
    }

    private void PortalCreated(string ip)
    {
        Debug.Log("Create portal");
        portalOn = true;
        WorldComponent.Sandbox.PortalDisposed.Subscribe(ClosePortal, ip);
    }

    private void ClosePortal()
    {
        Debug.Log("Close portal");
        portalOn = false;
    }


    void Update()
    {
        if (portalOn && portal == null)
            portal = (GameObject)Instantiate(Resources.Load("Prefab/Portal"));

        if (portalOn == false && portal != null)
        {
            Destroy(portal.gameObject);
            portal = null;
        }
    }
}
