using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;

    private Slider healthSlider;

    void Awake()
    {
        healthSlider = GetComponent<Slider>();
    }
    
    void Start()
    {
        if (playerHealth != null)
        {
            healthSlider.value = (float)playerHealth.GetHealth() / playerHealth.GetMaxHealth();
        }
    }

    void Update()
    {
        if (playerHealth != null)
        {
            healthSlider.value = (float)playerHealth.GetHealth() / playerHealth.GetMaxHealth();
        }
    }
}
