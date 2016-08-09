using UnityEngine;
using System.Collections;
using UnitySolution.InputComponents;

public class InputPunchOnTouch : MonoBehaviour {

    void Start()
    {
        var x = GetComponent<DetectTouchOnThisGameObject>();
        x.OnEnd += touchEnd;
        x.OnCancel += touchEnd;
        x.OnStart += touchStart;
        x.OnStay += touchStart;
    }

    private void touchStart(object sender, PointEventArgs e)
    {
        PlayerOneInput.SetPunch(true);
    }

    private void touchEnd(object sender, PointEventArgs e)
    {
        PlayerOneInput.SetPunch(false);
    }
}
