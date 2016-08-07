using UnityEngine;
using System.Collections;

public class IPAndPortDiplay : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        var zxczxc = new GUIStyle() { fontSize = 150 };
        GUILayout.Label("IP", zxczxc);
        GUILayout.Label("PORT", zxczxc);
    }
}
