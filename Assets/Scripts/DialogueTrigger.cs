using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private EndDialogueAction endAction;
    
    private bool inRange = false;
    private DialogueManager dialogueManager;
    private CapsuleCollider2D myCapsuleCollider;
    private CircleCollider2D myCircleCollider;
    
    // for Scene3 dungeon
    private OpenDoors openDoors;

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        endAction = GetComponent<EndDialogueAction>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
        myCircleCollider = GetComponent<CircleCollider2D>();
        openDoors = GetComponent<OpenDoors>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && inRange && !dialogueManager.PlayingDialogue())
        {
            TriggerDialogue();
            
            // open dungeon doors
            if (openDoors != null)
            {
                openDoors.KeyUsed();
            }
            
            // prevent repeating dialogue
            OpenDoorsEndAction doorsEndAct = FindObjectOfType<OpenDoorsEndAction>();
            if (endAction != null && doorsEndAct == null)
            {
                if (myCapsuleCollider != null)
                {
                    myCapsuleCollider.enabled = false;
                }

                if (myCircleCollider != null)
                {
                    myCircleCollider.enabled = false;
                }
            }
        }
    }
    
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, endAction);
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player" && gameObject.tag == "Boundary")
        {
            TriggerDialogue();
        }
    }
}
