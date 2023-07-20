using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private AudioSource audioSource;

    private Queue<string> sentences;
    private bool playingDialogue = false;
    private bool sentenceComplete = true;
    private EndDialogueAction currentEndAction;
    private Coroutine currCoroutine;
    private string currSentence;

    void Start()
    {
        sentences = new Queue<string>();
        dialogueBox.SetActive(false);
    }

    public bool PlayingDialogue()
    {
        return playingDialogue;
    }

    public void StartDialogue(Dialogue dialogue, EndDialogueAction endAction)
    {
        dialogueBox.SetActive(true);
        
        nameText.text = dialogue.name;
        dialogueText.text = "";
        currentEndAction = endAction;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        
        StartCoroutine(WaitForOpenAnimation());
    }

    public void DisplayNextSentence()
    {
        if (playingDialogue)
        {
            StopCoroutine(currCoroutine);
            dialogueText.text = currSentence;
            sentenceComplete = true;
            playingDialogue = false;
            if (audioSource != null)
            {
                audioSource.Stop();
            }
        }
        else if (sentenceComplete)
        {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }
            
            string sentence = sentences.Dequeue();
            currSentence = sentence;
            currCoroutine = StartCoroutine(TypeSentence(sentence));
        }
    }

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
        if (currentEndAction != null)
        {
            currentEndAction.EndAction();
            currentEndAction = null;
        }
    }

    // input system
    void OnDialogue()
    {
        if (dialogueBox.activeSelf)
        {
            DisplayNextSentence();
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        playingDialogue = true;
        
        dialogueText.text = "";

        if (audioSource != null)
        {
            audioSource.Play();
        }

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        
        if (audioSource != null)
        {
            audioSource.Stop();
        }
        
        playingDialogue = false;
    }

    IEnumerator WaitForOpenAnimation()
    {
        yield return new WaitForSeconds(0.3f);
        DisplayNextSentence();
    }
    
}
