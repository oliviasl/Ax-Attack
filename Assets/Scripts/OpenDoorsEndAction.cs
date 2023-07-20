using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorsEndAction : MonoBehaviour, EndDialogueAction
{
    [SerializeField] private string sceneName;
    [SerializeField] private bool noLock;

    private LevelManager levelManager;
    private bool keyUsed;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        keyUsed = false;
    }
    
    public void EndAction()
    {
        if (noLock)
        {
            levelManager.NextScene(sceneName);
        }
        if (keyUsed)
        {
            levelManager.NextScene(sceneName);
        }
    }

    public void SetKeyUse(bool use)
    {
        keyUsed = use;
    }
    
}
