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
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            ResetScreenPc.SetActive(true);
            SettingsScreenPc.SetActive(false);
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            SettingsScreenMobile.SetActive(true);
            ResetScreenMobile.SetActive(false);
        }
    }

    public void BackReset()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            ResetScreenPc.SetActive(false);
            SettingsScreenPc.SetActive(true);
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            ResetScreenMobile.SetActive(false);
            ResetScreenMobile.SetActive(true);
        }
    }

    public void AcceptReset()
    {
        for (int i = 0; i < 6; i++)
        {
            PlayerPrefs.SetInt("QuestLevelComplete" + i, 0);
            PlayerPrefs.SetInt("QuestNoKill" + i, 0);
            PlayerPrefs.SetInt("QuestAllKill" + i, 0);
            PlayerPrefs.SetInt("TotalQuest",0);
            Debug.Log("dsaaaaaaaaaaa");
        }
    }
}
