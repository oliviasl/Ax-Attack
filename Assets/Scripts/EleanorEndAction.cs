using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EleanorEndAction : MonoBehaviour, EndDialogueAction
{
    private LevelManager levelManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    public void EndAction()
    {
        levelManager.NextScene("Scene2");
    }
}
