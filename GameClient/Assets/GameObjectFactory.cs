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
    }

    private void ClosePortal()
    {
        Debug.Log("Close portal");
        portalOn = false;
    }

    private void PortalCreated(string obj)
    {
        Debug.Log("Create portal");
        portalOn = true;
        WorldComponent.Sandbox.CloseThePortal.Subscribe(ClosePortal, obj);
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
