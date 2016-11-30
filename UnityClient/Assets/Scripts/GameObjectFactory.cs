using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameObjectFactory : MonoBehaviour
{
    private readonly Dictionary<string, GameObject> Portals =
        new Dictionary<string, GameObject>();

    private readonly List<string> PortalsToCreate =
        new List<string>();

    private readonly List<GameObject> PortalsToDestroy =
        new List<GameObject>();
    
    void Start()
    {
        WorldComponent.Sandbox.PortalCreated.Subscribe(PortalCreated);
    }

    private void PortalCreated(string ip)
    {
        Debug.Log("Create portal");
        PortalsToCreate.Add(ip);
        WorldComponent.Sandbox.PortalDisposed.Subscribe(ClosePortal);
    }

    private void ClosePortal(string ip)
    {
        Debug.Log("Close portal");
        if (Portals.ContainsKey(ip))
        {
            if (Portals[ip] != null)
            {
                PortalsToDestroy.Add(Portals[ip]);
            }
        }
    }

    void Update()
    {
        foreach (var portal in PortalsToDestroy.ToList())
        {
            PortalsToDestroy.Remove(portal);
            Destroy(portal);
        }

        foreach (var ip in PortalsToCreate.ToList())
        {
            PortalsToCreate.Remove(ip);
            Portals[ip] = (GameObject)Instantiate(Resources.Load("Prefab/Portal"));
        }
    }
}
