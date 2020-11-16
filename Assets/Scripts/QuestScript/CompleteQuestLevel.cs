using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteQuestLevel : MonoBehaviour
{
    public GameObject GamePlayScreenPC;
    public GameObject GamePlayScreenMobile;
    public GameObject EndLevelScreenPc;
    public GameObject EndLevelScreenMobile;
    public static bool isFinishLevel;

    void Start()
    {
        isFinishLevel = false;
    }
    private void Update()
    {
        if (isFinishLevel == true)
        {
            CompleteLevel();
        }
    }
    public void CompleteLevel()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            GamePlayScreenPC.SetActive(true);
            EndLevelScreenPc.SetActive(true);
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            GamePlayScreenMobile.SetActive(true);
            EndLevelScreenMobile.SetActive(true);
        }
    }
    public void ChangeScene()
    {
        if (PlayerPrefs.GetInt("setMusic") == 1)
            AudioManager.instance.Play("Soundtrack");
        AudioManager.instance.Stop("Bird Sound");
        AudioManager.instance.Stop("Water Sound");
        SceneManager.LoadScene("LevelSelection");
    }
}
