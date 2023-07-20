using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSceneScroll : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [SerializeField] private Vector3 initialPosition;
    [SerializeField] private Vector3 boundPosition;
    
    void Update()
    {
        transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, -10);

        if (transform.position.x > boundPosition.x)
        {
            transform.position = initialPosition;
        }
    }
}
