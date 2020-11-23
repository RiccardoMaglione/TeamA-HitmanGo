using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishStamp6 : MonoBehaviour
{
    public GameObject PCFinishLevelStampCompleted;
    public GameObject PCFinishLevelStampNoKill;
    public GameObject PCFinishLevelStampAllKill;

    public GameObject MobileFinishLevelStampCompleted;
    public GameObject MobileFinishLevelStampNoKill;
    public GameObject MobileFinishLevelStampAllKill;

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "GO 1-6" || scene.name == "Level1-6+hint")
        {
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                if (PlayerPrefs.GetInt("QuestLevelComplete" + 5) == 1)
                {
                    PCFinishLevelStampCompleted.SetActive(true);
                }
                if (PlayerPrefs.GetInt("QuestNoKill" + 5) == 1)
                {
                    PCFinishLevelStampNoKill.SetActive(true);
                }
                if (PlayerPrefs.GetInt("QuestAllKill" + 5) == 1)
                {
                    PCFinishLevelStampAllKill.SetActive(true);
                }
            }
            if (Application.platform == RuntimePlatform.Android)
            {
                if (PlayerPrefs.GetInt("QuestLevelComplete" + 5) == 1)
                {
                    MobileFinishLevelStampCompleted.SetActive(true);
                }
                if (PlayerPrefs.GetInt("QuestNoKill" + 5) == 1)
                {
                    MobileFinishLevelStampNoKill.SetActive(true);
                }
                if (PlayerPrefs.GetInt("QuestAllKill" + 5) == 1)
                {
                    MobileFinishLevelStampAllKill.SetActive(true);
                }
            }
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                if (PlayerPrefs.GetInt("QuestLevelComplete" + 5) == 0)
                {
                    PCFinishLevelStampCompleted.SetActive(false);
                }
                if (PlayerPrefs.GetInt("QuestNoKill" + 5) == 0)
                {
                    PCFinishLevelStampNoKill.SetActive(false);
                }
                if (PlayerPrefs.GetInt("QuestAllKill" + 5) == 0)
                {
                    PCFinishLevelStampAllKill.SetActive(false);
                }
            }
            if (Application.platform == RuntimePlatform.Android)
            {
                if (PlayerPrefs.GetInt("QuestLevelComplete" + 5) == 0)
                {
                    MobileFinishLevelStampCompleted.SetActive(false);
                }
                if (PlayerPrefs.GetInt("QuestNoKill" + 5) == 0)
                {
                    MobileFinishLevelStampNoKill.SetActive(false);
                }
                if (PlayerPrefs.GetInt("QuestAllKill" + 5) == 0)
                {
                    MobileFinishLevelStampAllKill.SetActive(false);
                }
            }
        }
    }
}