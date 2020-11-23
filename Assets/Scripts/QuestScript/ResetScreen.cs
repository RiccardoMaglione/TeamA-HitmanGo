using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScreen : MonoBehaviour
{
    public GameObject SettingsScreenPc;
    public GameObject SettingsScreenMobile;

    public GameObject ResetScreenPc;
    public GameObject ResetScreenMobile;

    public void ActivateResetScreen()
    {
        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Selection Sound");
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            ResetScreenPc.SetActive(true);
            SettingsScreenPc.SetActive(false);
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            SettingsScreenMobile.SetActive(false);
            ResetScreenMobile.SetActive(true);
        }
    }

    public void BackReset()
    {
        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Selection Sound");

        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            ResetScreenPc.SetActive(false);
            SettingsScreenPc.SetActive(true);
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            ResetScreenMobile.SetActive(false);
            SettingsScreenMobile.SetActive(true);
        }
    }

    public void AcceptReset()
    {
        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Selection Sound");
        for (int i = 0; i < 6; i++)
        {
            PlayerPrefs.SetInt("QuestLevelComplete" + i, 0);
            PlayerPrefs.SetInt("QuestNoKill" + i, 0);
            PlayerPrefs.SetInt("QuestAllKill" + i, 0);
            PlayerPrefs.SetInt("TotalQuest",0);
            Debug.Log("dsaaaaaaaaaaa");
        }
        PlayerPrefs.SetInt("UnblockTwo", 0);
        PlayerPrefs.SetInt("UnblockThree", 0);
        PlayerPrefs.SetInt("UnblockFour", 0);
        PlayerPrefs.SetInt("UnblockFive", 0);
        PlayerPrefs.SetInt("UnblockSix", 0);
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            ResetScreenPc.SetActive(false);
            SettingsScreenPc.SetActive(true);
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            ResetScreenMobile.SetActive(false);
            SettingsScreenMobile.SetActive(true);
        }
    }
}
