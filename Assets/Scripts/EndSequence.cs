using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class EndSequence : MonoBehaviour
{
    [SerializeField] XRSocketInteractor[] sockets;
    int sockCount = 0;
    private void Start()
    {
        if(sockets != null)
        {
            for (int i = 0; i < sockets.Length; i++)
            {
                sockets[i].selectEntered.AddListener(KeyInserted);
                sockets[i].selectExited.AddListener(KeyRemoved);
            }
        }
    }
    private void Update()
    {
        if(sockCount >= 4)
        {
            SceneManager.LoadScene("Scn_End");
        }
    }
    private void KeyInserted(SelectEnterEventArgs arg0)
    {
        sockCount++;
    }
    private void KeyRemoved(SelectExitEventArgs arg0)
    {
        sockCount--;
    }
}
