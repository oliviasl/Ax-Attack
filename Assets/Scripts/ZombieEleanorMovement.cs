using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieEleanorMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private GameObject dialogueBox;
    
    private Rigidbody2D myRigidbody;
    private SpriteRenderer mySpriteRenderer;
    private Animator myAnimator;
    private new Camera camera;
    private bool canMove;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
        camera = FindObjectOfType<Camera>();
        canMove = true;
    }
    
    void Update()
    {
        float cameraX = camera.WorldToViewportPoint(transform.position).x;
        float cameraY = camera.WorldToViewportPoint(transform.position).y;
        if (cameraX > 0 && cameraX < 1 && cameraY > 0 && cameraY < 1)
        {
            Move();
            FlipSprite();
        }
    }

    public void FreezeMovement()
    {
        canMove = false;
    }

    public void UnfreezeMovement()
    {
        canMove = true;
    }

    private void Move()
    {
        if (player != null && canMove && !dialogueBox.activeSelf)
        {
            myAnimator.SetBool("isRunning", true);
            float dirX = player.transform.position.x - transform.position.x;
            float dirY = player.transform.position.y - transform.position.y;
            
            Vector2 velocityToTarget = new Vector2(dirX, dirY);
            
            velocityToTarget.Normalize();

            myRigidbody.velocity = moveSpeed * velocityToTarget;
        }
        else
        {
            myAnimator.SetBool("isRunning", false);
        }
    }

    private void FlipSprite()
    {
        if (Mathf.Sign(myRigidbody.velocity.x) > 0)
        {
            mySpriteRenderer.flipX = false;
        }
        else
        {
            mySpriteRenderer.flipX = true;
        }
    }
    
}
