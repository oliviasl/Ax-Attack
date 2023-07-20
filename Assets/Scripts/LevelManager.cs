using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private FadeScreen fadeScreen;
    [SerializeField] private AudioSource menuSelectAudio;
    private static LevelManager instance;

    void Awake()
    {
        ManageSingleton();
    }

    void Start()
    {
        fadeScreen.startFadeIn();
    }

    public void NextScene(string sceneName)
    {
        StartCoroutine(changeSceneFade(sceneName));
    }

    public void ReloadScene()
    { 
        StartCoroutine(changeSceneFade(SceneManager.GetActiveScene().name));
    }
    
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        if (menuSelectAudio != null)
        {
            menuSelectAudio.Play();
        }
        Application.Quit();
    }
    
    public void LoadGame()
    {
        if (menuSelectAudio != null)
        {
            menuSelectAudio.Play();
        }
        NextScene("Cutscene1");
    }

    private void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            instance.fadeScreen = this.fadeScreen;
            instance.fadeScreen.startFadeIn();
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    IEnumerator changeSceneFade(string sceneName)
    {
        fadeScreen.gameObject.SetActive(true);
        fadeScreen.startFadeOut();
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(sceneName);
    }
}
