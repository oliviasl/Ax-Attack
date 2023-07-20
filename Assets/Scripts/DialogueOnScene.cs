using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOnScene : MonoBehaviour
{
    [SerializeField] private DialogueTrigger trigger;
    void Start()
    {
        StartCoroutine(OpenDialogue());
    }

    IEnumerator OpenDialogue()
    {
        yield return new WaitForSeconds(1.0f);
        trigger.TriggerDialogue();
    }
}
