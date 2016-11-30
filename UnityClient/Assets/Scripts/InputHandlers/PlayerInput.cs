using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public void Update()
    {
#if !UNITY_ANDROID || UNITY_EDITOR
        var axis_h = Input.GetAxis("Horizontal");

        WorldComponent.Sandbox.RightPressed.Publish(axis_h > 0);
        WorldComponent.Sandbox.LeftPressed.Publish(axis_h < 0);
        WorldComponent.Sandbox.UpPressed.Publish(Input.GetKey(KeyCode.Space));
#endif
#if UNITY_EDITOR
        WorldComponent.Sandbox.UpPressed.Publish(Input.GetButton("Jump"));
#endif
    }
}