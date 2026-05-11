using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class AudioManager : MonoBehaviour
{
    [Header("Headlight")]
    [SerializeField] XRGrabInteractable headlight;
    [SerializeField] AudioSource headlightGet;
    [Header("Doors")]
    [SerializeField] SimpleHingeInteractable[] doors;
    [SerializeField] AudioSource[] doorSource;
    [SerializeField] AudioClip doorOpen, doorClose;
    [Header("Monster")]
    [SerializeField] AudioSource monsterSource;
    [SerializeField] AudioClip monsterMove;
    [Header("Keystones")]
    [SerializeField] XRGrabInteractable[] keystones;
    [SerializeField] AudioSource[] keySource;
    [SerializeField] AudioClip keyGet;
    [Header("Keystone Sockets")]   
    [SerializeField] XRSocketInteractor[] sockets;
    [SerializeField] AudioSource[] socketSource; 
    [SerializeField] AudioClip keyInsert;
    [Header("Puzzles")]
    [SerializeField] XRGrabInteractable[] rocks;
    [SerializeField] AudioSource[] rockSource;
    [SerializeField] AudioClip rockThud;
    [SerializeField] AudioSource gateOpen;
    [SerializeField] XRGrabInteractable[] tumblers;
    [SerializeField] AudioSource[] tumblerSource;
    [SerializeField] AudioClip tumbleTurn;
    [Header("Ending")]
    [SerializeField] AudioSource endDoorOpen;
    private void OnEnable()
    {
        if (headlight != null)
        {
            headlight.selectEntered.AddListener(PlayHeadlightGet);
        }
        SetDoors();
        SetMonsters();
        SetKeystones();
        SetSockets();
        SetRocks();
        SetTumblers();
    }
    private void OnDisable()
    {
        if (headlight != null)
        {
            headlight.selectEntered.RemoveListener(PlayHeadlightGet);
        }
        
    }
    
    private void SetDoors()
    {
        if (doors != null)
        {
            for (int i = 0; i < doors.Length; i++)
            {
                doorSource.Append(doors[i].AddComponent<AudioSource>());
                doors[i].selectEntered.AddListener(OnSelectEnteredDoor);
                doors[i].selectExited.AddListener(OnSelectExitedDoor);
            }
        }
    }
    private void SetMonsters()
    {
    }
    private void SetKeystones()
    {
        if (keystones != null)
        {
            for (int i = 0; i < keystones.Length; i++)
            {
                keySource.Append(keystones[i].AddComponent<AudioSource>());
                keystones[i].selectEntered.AddListener(OnSelectEnteredKey);
            }
        }
    }
    private void SetSockets()
    {
        if (sockets != null)
        {
            for (int i = 0; i < sockets.Length; i++)
            {
                socketSource.Append(sockets[i].AddComponent<AudioSource>());
                sockets[i].selectEntered.AddListener(OnSelectEnteredSock);
            }
        }
    }
    private void SetRocks()
    {
        if (rocks != null)
        {
            for (int i = 0; i < rocks.Length; i++)
            {
                rockSource.Append(rocks[i].AddComponent<AudioSource>());
            }
        }
    }
    private void SetTumblers()
    {
        if (tumblers != null)
        {
            for (int i = 0; i < tumblers.Length; i++)
            {
                tumblerSource.Append(tumblers[i].AddComponent<AudioSource>());
                tumblers[i].selectEntered.AddListener(OnSelectEnteredTumb);
                tumblers[i].selectExited.AddListener(OnSelectExitedTumb);
            }
        }
    }
    private void PlayHeadlightGet(SelectEnterEventArgs arg0)
    {
        if(headlightGet != null)
        {
            headlightGet.Play();
        }
    }
    private void OnSelectEnteredDoor(SelectEnterEventArgs arg0)
    {
        GameObject tempGameObject = arg0.interactableObject.transform.gameObject;
        tempGameObject.GetComponent<AudioSource>().clip = doorOpen;
        tempGameObject.GetComponent<AudioSource>().Play();
    }
    private void OnSelectExitedDoor(SelectExitEventArgs arg0)
    {
        GameObject tempGameObject = arg0.interactableObject.transform.gameObject;
        tempGameObject.GetComponent<AudioSource>().clip = doorClose;
        tempGameObject.GetComponent<AudioSource>().Play();
    }
    private void OnSelectEnteredKey(SelectEnterEventArgs arg0)
    {
        if(keyGet != null)
        {
            GameObject tempGameObject = arg0.interactableObject.transform.gameObject;
            tempGameObject.GetComponent<AudioSource>().clip = keyGet;
            tempGameObject.GetComponent<AudioSource>().Play();
        }
    }
    private void OnSelectEnteredSock(SelectEnterEventArgs arg0)
    {
        if(keyInsert != null)
        {
            GameObject tempGameObject = arg0.interactableObject.transform.gameObject;
            tempGameObject.GetComponent<AudioSource>().clip = keyInsert;
            tempGameObject.GetComponent<AudioSource>().Play();
        }
    }
    private void OnSelectEnteredTumb(SelectEnterEventArgs arg0)
    {
        if(tumbleTurn != null)
        {
            GameObject tempGameObject = arg0.interactableObject.transform.gameObject;
            tempGameObject.GetComponent<AudioSource>().clip = tumbleTurn;
            tempGameObject.GetComponent<AudioSource>().loop = true;
            tempGameObject.GetComponent<AudioSource>().Play();
        }
    }
    private void OnSelectExitedTumb(SelectExitEventArgs arg0)
    {
        GameObject tempGameObject = arg0.interactableObject.transform.gameObject;
        tempGameObject.GetComponent<AudioSource>().Stop();
    }

}
