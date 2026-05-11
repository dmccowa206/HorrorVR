using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] XRButtonInteractable startBtn;
    [SerializeField] AudioSource source;
    [SerializeField] float delay = 4.0f;
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
        if (source != null)
        {
            source.Play();
        }
        Invoke("GoToMain", delay);
    }
    private void GoToMain()
    {
        SceneManager.LoadScene("Scn_Main");
    }
}
