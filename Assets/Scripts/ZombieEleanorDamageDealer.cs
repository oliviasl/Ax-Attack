using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class ZombieEleanorDamageDealer : MonoBehaviour
{
    [SerializeField] private int damage = 4;
    [SerializeField] private ZombieEleanorMovement movement;
    [SerializeField] private Animator myAnimator;
    [SerializeField] private GameObject healthBar;

    private EndingOutcome endingOutcome;
    private AudioSource poofAudio;
    private PlayerHealth playerHealth;
    private bool isAlive;
    private float timeBetweenHits;
    
    void Start()
    {
        endingOutcome = FindObjectOfType<EndingOutcome>();
        poofAudio = GetComponent<AudioSource>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        gameObject.SetActive(false);
        healthBar.SetActive(false);
        isAlive = true;
        timeBetweenHits = 0f;
    }

    public int GetDamage()
    {
        if (isAlive)
        {
            return damage;
        }
        return 0;
    }

    public void Hit()
    {
        StartCoroutine(Death());
        endingOutcome.HumanEnding();
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        poofAudio.Play();
        healthBar.SetActive(true);
        StartCoroutine(Summon());
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            timeBetweenHits = 1.0f;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (isAlive && collision.gameObject.CompareTag("Player"))
        {
            timeBetweenHits += Time.deltaTime;
            if (timeBetweenHits >= 1.0f)
            {
                playerHealth.TakeDamage(damage);
                timeBetweenHits = 0;
            }
        }
    }

    IEnumerator Summon()
    {
        myAnimator.SetBool("isPoof", true);
        yield return new WaitForSeconds(0.75f);
        myAnimator.SetBool("isPoof", false);
    }

    IEnumerator Death()
    {
        isAlive = false;
        myAnimator.SetBool("isPoof", true);
        poofAudio.Play();
        yield return new WaitForSeconds(0.75f);
        Destroy(gameObject);
    }
}
