using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerSymbols : MonoBehaviour
{
    [SerializeField] private GameObject interactSymbol;

    private HashSet<string> interactables = new HashSet<string>();

    void Start()
    {
        interactSymbol.SetActive(false);
        interactables.Add("NPC");
        interactables.Add("Chest");
        interactables.Add("Doors");
        interactables.Add("Ax");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (interactables.Contains(other.tag))
        {
            interactSymbol.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (interactables.Contains(other.tag))
        {
            interactSymbol.SetActive(false);
        }
    }
}
