using UnityEngine;
using UnitySolution.InputComponents;
using Common;

public class InputPunchOnTouch : MonoBehaviour
{
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
        Player1Input.PunchPressed = true;
    }

    private void touchEnd(object sender, PointEventArgs e)
    {
        Player1Input.PunchPressed = false;
    }
}
