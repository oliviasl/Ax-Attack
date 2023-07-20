using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyManEndAction : MonoBehaviour, EndDialogueAction
{
    [SerializeField] private HealthPotionUse healthPotion;

    private Animator animator;
    private AudioSource poofAudio;

    void Start()
    {
        animator = GetComponent<Animator>();
        poofAudio = GetComponent<AudioSource>();
    }

    public void EndAction()
    {
        healthPotion.GetPotion();
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear()
    {
        animator.SetTrigger("disappear");
        poofAudio.Play();
        yield return new WaitForSeconds(0.75f);
        Destroy(gameObject);
    }
}
