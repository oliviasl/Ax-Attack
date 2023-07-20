using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenDoors : MonoBehaviour
{
    [SerializeField] private GameObject leftDoor;
    [SerializeField] private GameObject rightDoor;
    [SerializeField] private Sprite closedLeft;
    [SerializeField] private Sprite closedRight;
    [SerializeField] private Sprite openLeft;
    [SerializeField] private Sprite openRight;
    [SerializeField] private KeyUse key;

    private SpriteRenderer leftRenderer, rightRenderer;
    private AudioSource doorAudio;

    void Start()
    {
        leftRenderer = leftDoor.GetComponent<SpriteRenderer>();
        rightRenderer = rightDoor.GetComponent<SpriteRenderer>();
        doorAudio = GetComponent<AudioSource>();
        
        leftRenderer.sprite = closedLeft;
        rightRenderer.sprite = closedRight;
    }

    public void KeyUsed()
    {
        if (key.GetHasKey())
        {
            leftRenderer.sprite = openLeft;
            rightRenderer.sprite = openRight;
            doorAudio.Play();
            key.UseKey();
        }
    }
}
