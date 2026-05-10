using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] XRButtonInteractable startBtn;
    [SerializeField] XRSimpleInteractable startBtn1;
    private void Start()
    {
        if (startBtn != null)
        {
            Debug.Log("GameMan btn not null");
            startBtn.selectEntered.AddListener(StartButtonPressed);
        }
    }
    private void StartButtonPressed(SelectEnterEventArgs arg0)
    {
        Debug.Log("OnStartSelect");
        SceneManager.LoadScene("Scn_Main");
    }
}
