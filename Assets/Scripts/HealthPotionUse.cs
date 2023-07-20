using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionUse : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private AudioSource useBottleAudio;
    [SerializeField] private AudioSource takeBottleAudio;
    
    private bool hasPotion;

    void Start()
    {
        gameObject.SetActive(false);
    }
    
    void Update()
    {
        if (hasPotion && Input.GetKeyDown(KeyCode.P))
        {
            UsePotion();
        }
    }

    public void GetPotion()
    {
        gameObject.SetActive(true);
        takeBottleAudio.Play();
        hasPotion = true;
    }

    public void UsePotion()
    {
        useBottleAudio.Play();
        playerHealth.ResetHealth();
        gameObject.SetActive(false);
        hasPotion = false;
    }
}
