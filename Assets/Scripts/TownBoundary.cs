using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownBoundary : MonoBehaviour
{
    void Start()
    {
        Enable();
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }
}
