using System;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    [SerializeField] DoorInteractable door;
    [SerializeField] Animator doorAnim;
    const string DOOR_ANIM_CLIP = "PortcullisRaise";
    [SerializeField] AudioSource doorSound;
    private void OnEnable()
    {
        if(door != null)
        {
            door.OnOpen.AddListener(RaiseGate);
        }
    }
    private void OnDisable()
    {
        if(door != null)
        {
            door.OnOpen.RemoveListener(RaiseGate);
        }
    }

    private void RaiseGate()
    {
        if(doorAnim != null)
        {
            doorAnim.Play(DOOR_ANIM_CLIP, 0, 0f);
        }
        if (doorSound != null)
        {
            doorSound.Play();
        }
    }
}
