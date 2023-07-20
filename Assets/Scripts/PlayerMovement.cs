using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private GameObject dialogueBox;

    private Rigidbody2D myRigidbody;
    private Animator myAnimator;

    private Vector2 rawMoveInput;
    private bool playerMoving;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (dialogueBox == null || !dialogueBox.activeSelf)
        {
            Move();
            FlipSprite();
        }
        else
        {
            myRigidbody.velocity = new Vector2(0f, 0f);

            myAnimator.SetBool("isRunning", false);
        }
    }
    
    void OnMove(InputValue value)
    {
        rawMoveInput = value.Get<Vector2>();
    }

    void Move()
    {
        Vector2 playerVelocity = new Vector2(rawMoveInput.x * moveSpeed, rawMoveInput.y * moveSpeed);
        myRigidbody.velocity = playerVelocity;
        
        // running animation
        playerMoving = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon ||
                       Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;

        if (playerMoving)
        {
            myAnimator.SetBool("isRunning", true);
        }
        else
        {
            myAnimator.SetBool("isRunning", false);
        }
    }

    void FlipSprite()
    {
        if (playerMoving && Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon) {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }
}
