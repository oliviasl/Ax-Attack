using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenGhostEndAction : MonoBehaviour, EndDialogueAction
{
    [SerializeField] private RedPotionUse redPotion;
    [SerializeField] private string nextScene;

    private LevelManager levelManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    public void EndAction()
    {
        redPotion.GetPotion();
        levelManager.NextScene(nextScene);
    }
}
