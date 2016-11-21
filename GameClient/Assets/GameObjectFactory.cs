using UnityEngine;
using System.Collections;
using System;

public class GameObjectFactory : MonoBehaviour
{
    private bool portalOn = false;
    private UnityEngine.GameObject portal;

    void Start()
    {
        WorldComponent.Sandbox.PortalCreated.Subscribe(PortalCreated);        
        WorldComponent.Sandbox.CloseThePortal.Subscribe(ClosePortal);
    }

    private void ClosePortal()
    {
        portalOn = false;
    }

    private void PortalCreated(string obj)
    {
        portalOn = true;
    }

    void Update()
    {
        if(portalOn && portal == null)
        portal = (GameObject)Instantiate(Resources.Load("Prefab/Portal"));

        if (portalOn == false && portal != null)
        {
            Destroy(portal.gameObject);
            portal = null;
        }
    }
}
