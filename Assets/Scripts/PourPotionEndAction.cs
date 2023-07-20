using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourPotionEndAction : MonoBehaviour, EndDialogueAction
{
    [SerializeField] private RedPotionUse redPotion;
    [SerializeField] private ZombieEleanorDamageDealer zombieDamageDealer;
    [SerializeField] private DialogueTrigger summonDialogue;

    private MusicPlayer musicPlayer;

    void Start()
    {
        musicPlayer = FindObjectOfType<MusicPlayer>();
    }
    
    public void EndAction()
    {
        if (musicPlayer != null)
        {
            musicPlayer.PlayDungeonMusic();
        }
        redPotion.UsePotion();
        zombieDamageDealer.Activate();
        summonDialogue.TriggerDialogue();
    }
}
