using System;
using UnityEngine;

public class AnimatorComponent : MonoBehaviour
{
    Animator Animator;
    public Func<string> GetTriggerName = () => "Iddle";

    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        Animator.SetTrigger(GetTriggerName());
    }
}
