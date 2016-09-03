using UnityEngine;
using System.Collections;
using UnitySolution.InputComponents;
using Common;

public class InputRightOnTouch : MonoBehaviour {

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
        Player1Input.RightIsPressed = true;
    }

    private void touchEnd(object sender, PointEventArgs e)
    {
        Player1Input.RightIsPressed =false;
    }
}
