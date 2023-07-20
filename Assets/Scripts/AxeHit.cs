using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AxeHit : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;

    private bool canHit;

    void Start()
    {
        canHit = true;
    }

    public void DisableHits()
    {
        canHit = false;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        DealDamage(other);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        DealDamage(other);
    }

    private void DealDamage(Collider2D other)
    {
        if (canHit && playerAnimator != null && playerAnimator.GetBool("isSwing"))
        {
            DamageDealer damageDealer = other.GetComponent<DamageDealer>();
            ZombieEleanorDamageDealer zombieDamageDealer = other.GetComponent<ZombieEleanorDamageDealer>();
            if (damageDealer != null)
            {
                damageDealer.Hit();
            }
            else if (zombieDamageDealer != null)
            {
                zombieDamageDealer.Hit();
            }
        }
    }
}
