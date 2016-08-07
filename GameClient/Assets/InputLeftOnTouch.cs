using UnityEngine;
using System.Collections;
using System;
using UnitySolution.InputComponents;

public class InputLeftOnTouch : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        var x = GetComponent<DetectTouchOnThisGameObject>();
        x.OnEnd += touchEnd;        
        x.OnCancel += touchEnd;
        x.OnStart += touchStart;
        x.OnStay += touchStart;
    }

    private void touchStart(object sender, PointEventArgs e)
    {
        PlayerOneInput.SetLeft(true);
    }

    private void touchEnd(object sender, PointEventArgs e)
    {
        PlayerOneInput.SetLeft(false);
    }
}
