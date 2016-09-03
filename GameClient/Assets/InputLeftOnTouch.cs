using UnityEngine;
using UnitySolution.InputComponents;
using Common;

public class InputLeftOnTouch : MonoBehaviour
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
        Player1Input.LeftIsPressed = true;
    }

    private void touchEnd(object sender, PointEventArgs e)
    {
        Player1Input.LeftIsPressed = false;
    }
}
