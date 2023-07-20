using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int initialHealth = 10;
    [SerializeField] private SpriteRenderer mySpriteRenderer;
    [SerializeField] private Animator myAnimator;
    [SerializeField] private AudioSource gruntAudio;
    [SerializeField] private AxeHit axeHit;

    private int health;
    private LevelManager levelManager;
    private EndingOutcome endingOutcome;

    void Start()
    {
        health = initialHealth;
        levelManager = FindObjectOfType<LevelManager>();
        endingOutcome = FindObjectOfType<EndingOutcome>();
        if (mySpriteRenderer != null)
        {
            mySpriteRenderer.color = new Color(1, 1f, 1f, 1f);
        }
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetMaxHealth()
    {
        return initialHealth;
    }

    public void ResetHealth()
    {
        health = initialHealth;
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        StartCoroutine(HitAnimation());
        if (health <= 0)
        {
            axeHit.DisableHits();
            StartCoroutine(Die());
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        DamageDealer damageDealer = col.gameObject.GetComponent<DamageDealer>();
        if (damageDealer != null && damageDealer.GetDamage() > 0)
        {
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
        }
    }

    IEnumerator Die()
    {
        myAnimator.SetTrigger("isPoof");
        yield return new WaitForSeconds(0.5f);
        if (endingOutcome == null)
        {
            levelManager.ReloadScene();
        }
        else
        {
            endingOutcome.ZombieEnding();
        }
        Destroy(gameObject);
    }

    IEnumerator HitAnimation()
    {
        gruntAudio.Play();
        mySpriteRenderer.color = new Color(225/225f, 146/225f, 146/225f, 1f);
        yield return new WaitForSeconds(0.2f);
        mySpriteRenderer.color = new Color(1, 1, 1, 1f);
    }
    
}
