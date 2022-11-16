﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeUIManager : MonoBehaviour
{
    public void StartGame()
    {
        // Left blank for now until first level has been established
        // SceneManager.LoadScene("Level1");
    }

    public void ShowHomeMenu()
    {
        SceneManager.LoadScene("HomeScreen");
    }

    public void ShowOptionsMenu()
    {
        SceneManager.LoadScene("OptionsScreen");
    }

    public void ShowCredits()
    {
        SceneManager.LoadScene("CreditsScreen");
    }

    public void ExitGame()
    {

    }
}