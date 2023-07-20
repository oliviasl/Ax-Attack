using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyUse : MonoBehaviour
{
    [SerializeField] private DialogueTrigger doorDialogueTrigger;
    [SerializeField] private OpenDoorsEndAction endAction;

    private bool hasKey;

    void Start()
    {
        gameObject.SetActive(false);
        hasKey = false;
    }

    public void TakeKey()
    {
        gameObject.SetActive(true);
        hasKey = true;
        doorDialogueTrigger.dialogue.sentences = new[] { "It opened! Let's see what's inside." };
    }

    public void UseKey()
    {
        if (hasKey)
        {
            gameObject.SetActive(false);
            hasKey = false;
            endAction.SetKeyUse(true);
        }
    }

    public bool GetHasKey()
    {
        return hasKey;
    }
}
