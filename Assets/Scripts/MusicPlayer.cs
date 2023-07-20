using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource townMusic;
    [SerializeField] private AudioSource eerieMusic;
    [SerializeField] private AudioSource dungeonMusic;

    private static MusicPlayer instance;
    
    private HashSet<string> townMusicScenes = new HashSet<string>();
    private HashSet<string> eerieMusicScenes = new HashSet<string>();
    private HashSet<string> dungeonMusicScenes = new HashSet<string>();
    private string currentMusic;
    
    void Start()
    {
        ManageSingleton();
    }
    
    public void LoadSceneSets()
    {
        townMusicScenes.Add("MenuScene");
        townMusicScenes.Add("Scene2");
        townMusicScenes.Add("Scene2.5");
        townMusicScenes.Add("Scene5");
        townMusicScenes.Add("Scene6");
        townMusicScenes.Add("Scene7.2");
        eerieMusicScenes.Add("Cutscene1");
        eerieMusicScenes.Add("Scene1");
        eerieMusicScenes.Add("Scene4");
        eerieMusicScenes.Add("Scene7.1");
        dungeonMusicScenes.Add("Scene3");
    }

    public void UpdateMusic()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (townMusicScenes.Contains(currentScene))
        {
            if (currentMusic != "town")
            {
                townMusic.Play();
                eerieMusic.Stop();
                dungeonMusic.Stop();
                currentMusic = "town";
            }
        }
        else if (eerieMusicScenes.Contains(currentScene))
        {
            if (currentMusic != "eerie")
            {
                eerieMusic.Play();
                townMusic.Stop();
                dungeonMusic.Stop();
                currentMusic = "eerie";
            }
        }
        else if (dungeonMusicScenes.Contains(currentScene))
        {
            if (currentMusic != "dungeon")
            {
                dungeonMusic.Play();
                eerieMusic.Stop();
                townMusic.Stop();
                currentMusic = "dungeon";
            }
        }
    }

    public void PlayDungeonMusic()
    {
        dungeonMusic.Play();
        eerieMusic.Stop();
        townMusic.Stop();
        currentMusic = "dungeon";
    }

    private void ManageSingleton()
    {
        if (instance != null)
        {
            instance.UpdateMusic();
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            LoadSceneSets();
            UpdateMusic();
            DontDestroyOnLoad(gameObject);
        }
    }

}
