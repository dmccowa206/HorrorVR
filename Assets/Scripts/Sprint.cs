using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Movement;

public class Sprint : MonoBehaviour
{
    [SerializeField] float baseSpeed = 1.0f;
    [SerializeField] float sprintSpeed = 3.0f;
    [SerializeField] ContinuousMoveProvider move;
    [SerializeField] InputActionReference leftSprintBtn;
    [SerializeField] InputActionReference rightSprintBtn;
    bool leftIn = false, rightIn = false;
    private void OnEnable()
    {
    }
    private void Update()
    {
        if (leftSprintBtn != null)
        {
            leftIn = leftSprintBtn.action.IsPressed();
        }
        if (rightSprintBtn != null)
        {
            rightIn = rightSprintBtn.action.IsPressed();
        }
        RunToggle(leftIn || rightIn);
    }
    private void RunToggle(bool btnHeld)
    {
        if (move != null)
        {
            if(btnHeld)
            {
                move.moveSpeed = sprintSpeed;
            }
            else
            {
                move.moveSpeed = baseSpeed;
            }
        }
    }
}
