using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxPickUpEndAction : MonoBehaviour, EndDialogueAction
{
    [SerializeField] private GameObject playerAxe;
    [SerializeField] private GameObject doorsNoAxe;
    [SerializeField] private GameObject doorsWithAxe;
    [SerializeField] private AudioSource takeAxAudio;
    
    void Start()
    {
        gameObject.SetActive(true);
        playerAxe.SetActive(false);
        doorsNoAxe.SetActive(true);
        doorsWithAxe.SetActive(false);
    }

    public void EndAction()
    {
        if (takeAxAudio != null)
        {
            takeAxAudio.Play();
        }
        gameObject.SetActive(false);
        playerAxe.SetActive(true);
        doorsNoAxe.SetActive(false);
        doorsWithAxe.SetActive(true);
    }
}
