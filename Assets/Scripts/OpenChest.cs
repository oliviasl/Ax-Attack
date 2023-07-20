using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    [SerializeField] private Sprite closedChest;
    [SerializeField] private Sprite openChest;
    [SerializeField] private KeyUse keyInventory;

    private SpriteRenderer mySpriteRenderer;
    private AudioSource chestAudio;
    private bool inRange;
    private bool opened;
    
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        chestAudio = GetComponent<AudioSource>();
        mySpriteRenderer.sprite = closedChest;
        inRange = false;
        opened = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && inRange && !opened)
        {
            opened = true;
            mySpriteRenderer.sprite = openChest;
            chestAudio.Play();
            keyInventory.TakeKey();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inRange = false;
        }
    }
}
