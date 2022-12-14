using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeUIManager : MonoBehaviour
{
    public static HomeUIManager instance;
    public AudioClip buttonPress;
    public AudioClip music;

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
        AudioManager.instance.PlayGameplayMusic();
    }

    public void RestartGame() {
        Debug.Log("RESTART CLICKED");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowHomeMenu()
    {
        SceneManager.LoadScene("HomeScreen");
        AudioManager.instance.PlaySound(buttonPress);
    }

    public void ReturnFromGameOver()
    {
        SceneManager.LoadScene("HomeScreen");
        AudioManager.instance.PlayMainMenuMusic();
        AudioManager.instance.PlaySound(buttonPress);
    }

    public void ShowOptionsMenu()
    {
        SceneManager.LoadScene("OptionsScreen");
        AudioManager.instance.PlaySound(buttonPress);
    }

    public void ShowCredits()
    {
        SceneManager.LoadScene("CreditsScreen");
        AudioManager.instance.PlaySound(buttonPress);
    }

    public void ExitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false; // allows quit functionality in editor mode
    }
}
