using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeUIManager : MonoBehaviour
{
    public static HomeUIManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("TopFloorMain");
    }

    public void ShowHomeMenu()
    {
        SceneManager.LoadScene("HomeScreen");
        AudioManager.instance.ButtonPress();
    }

    public void ShowOptionsMenu()
    {
        SceneManager.LoadScene("OptionsScreen");
        AudioManager.instance.ButtonPress();
    }

    public void ShowCredits()
    {
        SceneManager.LoadScene("CreditsScreen");
        AudioManager.instance.ButtonPress();
    }

    public void ExitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false; // allows quit functionality in editor mode
    }
}
