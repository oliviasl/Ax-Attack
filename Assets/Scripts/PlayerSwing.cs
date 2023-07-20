using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwing : MonoBehaviour
{
    [SerializeField] private AudioSource axAudio;
    
    private Animator animator;
    private bool isSwing;

    void Start()
    {
        animator = GetComponent<Animator>();
        isSwing = false;
    }

    void OnSwing()
    {
        if (!isSwing)
        {
            StartCoroutine(SwingAxe());
        }
    }

    IEnumerator SwingAxe()
    {
        isSwing = true;
        animator.SetBool("isSwing", true);
        axAudio.Play();
        yield return new WaitForSeconds(0.45f);
        animator.SetBool("isSwing", false);
        isSwing = false;
    }
}
