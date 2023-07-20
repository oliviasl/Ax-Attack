using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;

    private LevelManager levelManager;
    
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();

        if (levelManager != null)
        {
            startButton.onClick.AddListener(levelManager.LoadGame);
            exitButton.onClick.AddListener(levelManager.QuitGame);
        }
    }
    
}
