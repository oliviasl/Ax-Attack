using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneEndAction : MonoBehaviour, EndDialogueAction
{
    [SerializeField] private string nextScene;

    private LevelManager levelManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    public void EndAction()
    {
        levelManager.NextScene(nextScene);
    }
}
