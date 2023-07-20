using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeed = 5.0f;

    private Rigidbody2D myRigidbody;
    private SpriteRenderer mySpriteRenderer;
    private new Camera camera;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        camera = FindObjectOfType<Camera>();
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
    
    private void Move()
    {
        if (player != null)
        {
            float dirX = player.transform.position.x - transform.position.x;
            float dirY = player.transform.position.y - transform.position.y;
            
            Vector2 velocityToTarget = new Vector2(dirX, dirY);
            
            velocityToTarget.Normalize();

            myRigidbody.velocity = moveSpeed * velocityToTarget;
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
