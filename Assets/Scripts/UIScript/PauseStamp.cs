using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseStamp : MonoBehaviour
{
    public GameObject PCNotFinishLevelStamp;
    public GameObject PCFinishLevelStamp;

    public GameObject MobileNotFinishLevelStamp;
    public GameObject MobileFinishLevelStamp;
    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "GO 1-1" || scene.name == "Leve1-1+hint")
        {
            if(PlayerPrefs.GetInt("QuestLevelComplete" + 0) == 1)
            {
                if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
                {
                    PCNotFinishLevelStamp.SetActive(false);
                    PCFinishLevelStamp.SetActive(true);
                }
                if (Application.platform == RuntimePlatform.Android)
                {
                    MobileNotFinishLevelStamp.SetActive(false);
                    MobileFinishLevelStamp.SetActive(true);
                }
            }
            if (PlayerPrefs.GetInt("QuestLevelComplete" + 0) == 0)
            {
                if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
                {
                    PCNotFinishLevelStamp.SetActive(true);
                    PCFinishLevelStamp.SetActive(false);
                }
                if (Application.platform == RuntimePlatform.Android)
                {
                    MobileNotFinishLevelStamp.SetActive(true);
                    MobileFinishLevelStamp.SetActive(false);
                }
            }
        }
        if (scene.name == "GO 1-2" || scene.name == "Leve1-2+hint")
        {
            if (PlayerPrefs.GetInt("QuestLevelComplete" + 1) == 1)
            {
                if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
                {
                    PCNotFinishLevelStamp.SetActive(false);
                    PCFinishLevelStamp.SetActive(true);
                }
                if (Application.platform == RuntimePlatform.Android)
                {
                    MobileNotFinishLevelStamp.SetActive(false);
                    MobileFinishLevelStamp.SetActive(true);
                }
            }
            if (PlayerPrefs.GetInt("QuestLevelComplete" + 1) == 0)
            {
                if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
                {
                    PCNotFinishLevelStamp.SetActive(true);
                    PCFinishLevelStamp.SetActive(false);
                }
                if (Application.platform == RuntimePlatform.Android)
                {
                    MobileNotFinishLevelStamp.SetActive(true);
                    MobileFinishLevelStamp.SetActive(false);
                }
            }
        }
        if (scene.name == "GO 1-3" || scene.name == "Leve1-3+hint")
        {
            if (PlayerPrefs.GetInt("QuestLevelComplete" + 2) == 1)
            {
                if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
                {
                    PCNotFinishLevelStamp.SetActive(false);
                    PCFinishLevelStamp.SetActive(true);
                }
                if (Application.platform == RuntimePlatform.Android)
                {
                    MobileNotFinishLevelStamp.SetActive(false);
                    MobileFinishLevelStamp.SetActive(true);
                }
            }
            if (PlayerPrefs.GetInt("QuestLevelComplete" + 2) == 0)
            {
                if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
                {
                    PCNotFinishLevelStamp.SetActive(true);
                    PCFinishLevelStamp.SetActive(false);
                }
                if (Application.platform == RuntimePlatform.Android)
                {
                    MobileNotFinishLevelStamp.SetActive(true);
                    MobileFinishLevelStamp.SetActive(false);
                }
            }
        }
        if (scene.name == "GO 1-4" || scene.name == "Leve1-4+hint")
        {
            if (PlayerPrefs.GetInt("QuestLevelComplete" + 3) == 1)
            {
                if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
                {
                    PCNotFinishLevelStamp.SetActive(false);
                    PCFinishLevelStamp.SetActive(true);
                }
                if (Application.platform == RuntimePlatform.Android)
                {
                    MobileNotFinishLevelStamp.SetActive(false);
                    MobileFinishLevelStamp.SetActive(true);
                }
            }
            if (PlayerPrefs.GetInt("QuestLevelComplete" + 3) == 0)
            {
                if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
                {
                    PCNotFinishLevelStamp.SetActive(true);
                    PCFinishLevelStamp.SetActive(false);
                }
                if (Application.platform == RuntimePlatform.Android)
                {
                    MobileNotFinishLevelStamp.SetActive(true);
                    MobileFinishLevelStamp.SetActive(false);
                }
            }
        }
        if (scene.name == "GO 1-5" || scene.name == "Leve1-5+hint")
        {
            if (PlayerPrefs.GetInt("QuestLevelComplete" + 4) == 1)
            {
                if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
                {
                    PCNotFinishLevelStamp.SetActive(false);
                    PCFinishLevelStamp.SetActive(true);
                }
                if (Application.platform == RuntimePlatform.Android)
                {
                    MobileNotFinishLevelStamp.SetActive(false);
                    MobileFinishLevelStamp.SetActive(true);
                }
            }
            if (PlayerPrefs.GetInt("QuestLevelComplete" + 4) == 0)
            {
                if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
                {
                    PCNotFinishLevelStamp.SetActive(true);
                    PCFinishLevelStamp.SetActive(false);
                }
                if (Application.platform == RuntimePlatform.Android)
                {
                    MobileNotFinishLevelStamp.SetActive(true);
                    MobileFinishLevelStamp.SetActive(false);
                }
            }
        }
    }
}
