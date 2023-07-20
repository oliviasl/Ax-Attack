using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damage = 2;
    [SerializeField] private bool isEnemy;
    [SerializeField] private AudioSource poofAudio;

    private Animator myAnimator;
    private bool active;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        active = true;
    }

    public int GetDamage()
    {
        if (active)
        {
            return damage;
        }
        return 0;
    }

    public void Hit()
    {
        if (isEnemy)
        {
            StartCoroutine(Death());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Death()
    {
        active = false;
        if (poofAudio != null)
        {
            poofAudio.Play();
        }
        myAnimator.SetTrigger("isHit");
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
