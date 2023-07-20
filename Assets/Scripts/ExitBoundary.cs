using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBoundary : MonoBehaviour
{
    [SerializeField] private string nextScene;
    private LevelManager levelManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && nextScene != null)
        {
            levelManager.NextScene(nextScene);
        }
    }
}
