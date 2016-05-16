using UnityEngine;
using UnitySolution.InputComponents;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(DetectTouchOnThisGameObject))]
public class StartHostingOnTouch : MonoBehaviour
{
    void Start()
    {
        GetComponent<DetectTouchOnThisGameObject>().OnEnd += TouchDetector_OnEnd;
    }

    private void TouchDetector_OnEnd(object sender, PointEventArgs e)
    {
        SceneManager.LoadScene("ChatAsHost");
    }
}
