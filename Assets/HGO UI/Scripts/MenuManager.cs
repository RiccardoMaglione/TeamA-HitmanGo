﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject startingScreenPC;
    public GameObject exitScreenPC;
    public GameObject settingScreenPC;
    //public GameObject stageSelectionScreenPC;
    public GameObject creditsScreenPC;
   
    public GameObject startingScreenMobile;
    public GameObject settingScreenMobile;
    //public GameObject stageSelectionScreenMobile;
    public GameObject creditsScreenMobile;


    public void GoToExitScreen()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            exitScreenPC.SetActive(true);
            startingScreenPC.SetActive(false);
            settingScreenPC.SetActive(false);
            //stageSelectionScreenPC.SetActive(false);
            creditsScreenPC.SetActive(false);
        }
    }

    public void GoToStartingScreen()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            startingScreenPC.SetActive(true);
            exitScreenPC.SetActive(false);
            settingScreenPC.SetActive(false);
            //stageSelectionScreenPC.SetActive(false);
            creditsScreenPC.SetActive(false);
        }

        else
        {
            startingScreenMobile.SetActive(true);
            settingScreenMobile.SetActive(false);
            //stageSelectionScreenMobile.SetActive(false);
            creditsScreenMobile.SetActive(false);
        }
    }

    public void GoToSettingScreen()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            settingScreenPC.SetActive(true);
            startingScreenPC.SetActive(false);
            exitScreenPC.SetActive(false);
            //stageSelectionScreenPC.SetActive(false);
            creditsScreenPC.SetActive(false);
        }

        else
        {
            settingScreenMobile.SetActive(true);
            startingScreenMobile.SetActive(false);
            //stageSelectionScreenMobile.SetActive(false);
            creditsScreenMobile.SetActive(false);
        }
    }

    public void GoToStageSelectionScreen()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            //stageSelectionScreenPC.SetActive(true);
            settingScreenPC.SetActive(false);
            startingScreenPC.SetActive(false);
            exitScreenPC.SetActive(false);
            creditsScreenPC.SetActive(false);
        }

        else
        {
            //stageSelectionScreenMobile.SetActive(true);
            settingScreenMobile.SetActive(false);
            startingScreenMobile.SetActive(false);
            creditsScreenMobile.SetActive(false);
        }
    }

    public void GoToCreditsScreen()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            //stageSelectionScreenPC.SetActive(false);
            settingScreenPC.SetActive(false);
            startingScreenPC.SetActive(false);
            exitScreenPC.SetActive(false);
            creditsScreenPC.SetActive(true);
        }

        else
        {
            //stageSelectionScreenMobile.SetActive(false);
            settingScreenMobile.SetActive(false);
            startingScreenMobile.SetActive(false);
            creditsScreenMobile.SetActive(true);
        }
    }

    public void GoToLevelSelectionScreen()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            //stageSelectionScreenPC.SetActive(false);
            settingScreenPC.SetActive(false);
            startingScreenPC.SetActive(false);
            exitScreenPC.SetActive(false);
            creditsScreenPC.SetActive(false);         
        }

        else
        {
            //stageSelectionScreenMobile.SetActive(false);
            settingScreenMobile.SetActive(false);
            startingScreenMobile.SetActive(false);
            creditsScreenMobile.SetActive(false);           
        }
    }

    public void GoToStageSelection()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StageSelection");
    }

    public void ExitApllication()
    {
        Application.Quit();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
