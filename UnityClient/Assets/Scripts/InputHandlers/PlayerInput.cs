using Common.GameComponents.PlayerComponents;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    void Start()
    {
        WorldComponent.Sandbox.PlayerUpdateAfterCollisions.Subscribe(OnPlayerUpdated);
    }

    string pname = null;
    private void OnPlayerUpdated(Player obj)
    {
        if (pname == null)
            pname = obj.Body.Name;
    }

    public void Update()
    {
        if (pname != null)
        {
#if !UNITY_ANDROID || UNITY_EDITOR
            var axis_h = Input.GetAxis("Horizontal");

            WorldComponent.Sandbox.RightPressed.Publish(axis_h > 0, pname);
            WorldComponent.Sandbox.LeftPressed.Publish(axis_h < 0, pname);
            WorldComponent.Sandbox.UpPressed.Publish(Input.GetKey(KeyCode.Space), pname);
#endif
#if UNITY_EDITOR
            WorldComponent.Sandbox.UpPressed.Publish(Input.GetButton("Jump"), pname);
#endif
        }
    }
}