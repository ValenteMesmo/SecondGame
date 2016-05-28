using UnityEngine;
using GameCore;

public class PlayerInput : MonoBehaviour
{

    ISetUserInputs inputs;
    void Start()
    {
        inputs = Factory.GetInputSetter();
    }

    public void SetLeft()
    {
        inputs.SetLeftPressed();
    }

    public void SetRight()
    {
        inputs.SetRightPressed();
    }
}
