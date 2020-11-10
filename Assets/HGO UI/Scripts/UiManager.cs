﻿using HGO.core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public GameObject gameScreenPC;
    public GameObject pauseScreeenPC;
    public GameObject gameScreenMobile;
    public GameObject pauseScreeenMobile;

    private PlayerMovement playerMovement;

    public void GoToGameScreen()
    {
        AudioManager.instance.Play("Selection Sound");
        playerMovement.Enable();
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            gameScreenPC.SetActive(true);
            pauseScreeenPC.SetActive(false);
        }

        else
        {
            gameScreenMobile.SetActive(true);
            pauseScreeenMobile.SetActive(false);
        }
    }

    public void GoToPauseScreen()
    {
        AudioManager.instance.Play("Selection Sound");
        playerMovement.Disable();
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            pauseScreeenPC.SetActive(true);
            gameScreenPC.SetActive(false);
        }

        else
        {
            pauseScreeenMobile.SetActive(true);
            gameScreenMobile.SetActive(false);
        }
    }

    public void ReloadScene()
    {
        AudioManager.instance.Play("Selection Sound");
        playerMovement.Enable();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToLevelSelection()
    {       
        AudioManager.instance.Stop("Water Sound");
        AudioManager.instance.Stop("Bird Sound");
        AudioManager.instance.Play("Selection Sound");
        AudioManager.instance.Play("Soundtrack");
        playerMovement.Enable();
        SceneManager.LoadScene("LevelSelection");
    }


    void Awake()
    {
        if (!playerMovement)
            playerMovement = FindObjectOfType<PlayerMovement>();
    }
}
