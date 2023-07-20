using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldWomanEndAction : MonoBehaviour, EndDialogueAction
{
    [SerializeField] private TownBoundary eastBoundary;
    [SerializeField] private DialogueTrigger narrator;
    
    private Animator animator;
    private AudioSource poofAudio;

    void Start()
    {
        animator = GetComponent<Animator>();
        poofAudio = GetComponent<AudioSource>();
    }

    public void EndAction()
    {
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear()
    {
        eastBoundary.Disable();
        animator.SetTrigger("disappear");
        poofAudio.Play();
        yield return new WaitForSeconds(0.75f);
        if (narrator != null)
        {
            narrator.TriggerDialogue();
        }
        Destroy(gameObject);
    }
}
