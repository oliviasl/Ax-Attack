using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    [SerializeField] bool toggleScreen;
    private Image image;
    
    void Start()
    {
        image = GetComponent<Image>();
        if (toggleScreen)
        {
            image.color = new Color(0, 0, 0, 1);
        }
        else
        {
            image.color = new Color(0, 0, 0, 0);
        }
    }

    public void startFadeIn()
    {
        StartCoroutine(FadeIn());
    }

    public void startFadeOut()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeIn()
    {
        image = GetComponent<Image>();
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            image.color = new Color(0, 0, 0, i);
            yield return null;
        }
        gameObject.SetActive(false);
    }

    IEnumerator FadeOut()
    {
        gameObject.SetActive(true);
        image = GetComponent<Image>();
        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            // set color with i as alpha
            image.color = new Color(0, 0, 0, i);
            yield return null;
        }
    }
}
