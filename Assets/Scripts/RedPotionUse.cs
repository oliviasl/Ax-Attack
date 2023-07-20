using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPotionUse : MonoBehaviour
{
    [SerializeField] private GameObject potionObject;
    [SerializeField] private bool hasPotion;
    [SerializeField] private AudioSource bottleAudio;
    [SerializeField] private AudioSource takeBottleAudio;
    
    void Start()
    {
        if (hasPotion)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
            if (potionObject != null)
            {
                potionObject.SetActive(true);
            }
        }
    }

    public void GetPotion()
    {
        potionObject.SetActive(false);
        if (takeBottleAudio != null)
        {
            takeBottleAudio.Play();
        }
        gameObject.SetActive(true);
    }

    public void UsePotion()
    {
        if (bottleAudio != null)
        {
            bottleAudio.Play();
        }
        gameObject.SetActive(false);
    }
    
}
