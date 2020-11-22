using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseStamp6 : MonoBehaviour
{
    public GameObject PCNotFinishLevelStampCompleted;
    public GameObject PCNotFinishLevelStampNoKill;
    public GameObject PCNotFinishLevelStampAllKill;

    public GameObject PCFinishLevelStampCompleted;
    public GameObject PCFinishLevelStampNoKill;
    public GameObject PCFinishLevelStampAllKill;

    public GameObject MobileNotFinishLevelStampCompleted;
    public GameObject MobileNotFinishLevelStampNoKill;
    public GameObject MobileNotFinishLevelStampAllKill;

    public GameObject MobileFinishLevelStampCompleted;
    public GameObject MobileFinishLevelStampNoKill;
    public GameObject MobileFinishLevelStampAllKill;

    Scene scene = SceneManager.GetActiveScene();
    // Start is called before the first frame update
    void Start()
    {
        if (scene.name == "GO 1-6" || scene.name == "Leve1-6+hint")
        {
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                if (PlayerPrefs.GetInt("QuestLevelComplete" + 4) == 1)
                {
                    PCNotFinishLevelStampCompleted.SetActive(false);
                }
                if (PlayerPrefs.GetInt("QuestNoKill" + 4) == 1)
                {
                    PCNotFinishLevelStampNoKill.SetActive(false);
                }
                if (PlayerPrefs.GetInt("QuestAllKill" + 4) == 1)
                {
                    PCNotFinishLevelStampAllKill.SetActive(false);
                }

                if (PlayerPrefs.GetInt("QuestLevelComplete" + 4) == 1)
                {
                    PCFinishLevelStampCompleted.SetActive(true);
                }
                if (PlayerPrefs.GetInt("QuestNoKill" + 4) == 1)
                {
                    PCFinishLevelStampNoKill.SetActive(true);
                }
                if (PlayerPrefs.GetInt("QuestAllKill" + 4) == 1)
                {
                    PCFinishLevelStampAllKill.SetActive(true);
                }
            }
            if (Application.platform == RuntimePlatform.Android)
            {
                if (PlayerPrefs.GetInt("QuestLevelComplete" + 4) == 1)
                {
                    MobileNotFinishLevelStampCompleted.SetActive(false);
                }
                if (PlayerPrefs.GetInt("QuestNoKill" + 4) == 1)
                {
                    MobileNotFinishLevelStampNoKill.SetActive(false);
                }
                if (PlayerPrefs.GetInt("QuestAllKill" + 4) == 1)
                {
                    MobileNotFinishLevelStampAllKill.SetActive(false);
                }

                if (PlayerPrefs.GetInt("QuestLevelComplete" + 4) == 1)
                {
                    MobileFinishLevelStampCompleted.SetActive(true);
                }
                if (PlayerPrefs.GetInt("QuestNoKill" + 4) == 1)
                {
                    MobileFinishLevelStampNoKill.SetActive(true);
                }
                if (PlayerPrefs.GetInt("QuestAllKill" + 4) == 1)
                {
                    MobileFinishLevelStampAllKill.SetActive(true);
                }
            }
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                if (PlayerPrefs.GetInt("QuestLevelComplete" + 4) == 0)
                {
                    PCNotFinishLevelStampCompleted.SetActive(true);
                }
                if (PlayerPrefs.GetInt("QuestNoKill" + 4) == 0)
                {
                    PCNotFinishLevelStampNoKill.SetActive(true);
                }
                if (PlayerPrefs.GetInt("QuestAllKill" + 4) == 0)
                {
                    PCNotFinishLevelStampAllKill.SetActive(true);
                }

                if (PlayerPrefs.GetInt("QuestLevelComplete" + 4) == 0)
                {
                    PCFinishLevelStampCompleted.SetActive(false);
                }
                if (PlayerPrefs.GetInt("QuestNoKill" + 4) == 0)
                {
                    PCFinishLevelStampNoKill.SetActive(false);
                }
                if (PlayerPrefs.GetInt("QuestAllKill" + 4) == 0)
                {
                    PCFinishLevelStampAllKill.SetActive(false);
                }
            }
            if (Application.platform == RuntimePlatform.Android)
            {
                if (PlayerPrefs.GetInt("QuestLevelComplete" + 4) == 0)
                {
                    MobileNotFinishLevelStampCompleted.SetActive(true);
                }
                if (PlayerPrefs.GetInt("QuestNoKill" + 4) == 0)
                {
                    MobileNotFinishLevelStampNoKill.SetActive(true);
                }
                if (PlayerPrefs.GetInt("QuestAllKill" + 4) == 0)
                {
                    MobileNotFinishLevelStampAllKill.SetActive(true);
                }

                if (PlayerPrefs.GetInt("QuestLevelComplete" + 4) == 0)
                {
                    MobileFinishLevelStampCompleted.SetActive(false);
                }
                if (PlayerPrefs.GetInt("QuestNoKill" + 4) == 0)
                {
                    MobileFinishLevelStampNoKill.SetActive(false);
                }
                if (PlayerPrefs.GetInt("QuestAllKill" + 4) == 0)
                {
                    MobileFinishLevelStampAllKill.SetActive(false);
                }
            }
        }
    }
}
