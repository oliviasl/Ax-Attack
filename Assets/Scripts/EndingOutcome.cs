using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingOutcome : MonoBehaviour
{
    [SerializeField] private GameObject zombieEleanor;
    [SerializeField] private GameObject player;
    private LevelManager levelManager;
    
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    public void ZombieEnding()
    {
        levelManager.NextScene("Scene7.1");
    }

    public void HumanEnding()
    {
        levelManager.NextScene("Scene7.2");
    }
}
