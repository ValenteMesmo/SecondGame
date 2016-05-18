using UnityEngine;
using UnitySolution.InputComponents;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(DetectTouchOnThisGameObject))]
public class ChangeSceneOnTouch : MonoBehaviour
{
    public string SceneName;

    void Start()
    {
        GetComponent<DetectTouchOnThisGameObject>().OnEnd += TouchDetector_OnEnd;
    }

    private void TouchDetector_OnEnd(object sender, PointEventArgs e)
    {
        SceneManager.LoadScene(SceneName);
    }
}
