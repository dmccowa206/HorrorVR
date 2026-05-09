using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnScript : MonoBehaviour
{
    public InputActionProperty triggerValue;
    public InputActionProperty gripValue;
    public Animator animator;
    void Update()
    {
        float trigger = triggerValue.action.ReadValue<float>();
        float grip = gripValue.action.ReadValue<float>();
        animator.SetFloat("Trigger", trigger);
        animator.SetFloat("Grip", grip);
    }
}
