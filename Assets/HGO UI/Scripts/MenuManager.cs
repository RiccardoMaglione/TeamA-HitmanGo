using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject startingScreenPC;
    public GameObject exitScreenPC;
    public GameObject settingScreenPC;
    public GameObject creditsScreenPC;
   
    public GameObject startingScreenMobile;
    public GameObject settingScreenMobile;
    public GameObject creditsScreenMobile;

    public void GoToExitScreen()
    {
        AudioManager.instance.Play("Selection Sound");
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            exitScreenPC.SetActive(true);
            startingScreenPC.SetActive(false);
            settingScreenPC.SetActive(false);
            creditsScreenPC.SetActive(false);
        }
    }

    public void GoToStartingScreen()
    {
        AudioManager.instance.Play("Selection Sound");
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            startingScreenPC.SetActive(true);
            exitScreenPC.SetActive(false);
            settingScreenPC.SetActive(false);
            creditsScreenPC.SetActive(false);
        }

        else
        {
            startingScreenMobile.SetActive(true);
            settingScreenMobile.SetActive(false);
            creditsScreenMobile.SetActive(false);
        }
    }

    public void GoToSettingScreen()
    {
        AudioManager.instance.Play("Selection Sound");
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            settingScreenPC.SetActive(true);
            startingScreenPC.SetActive(false);
            exitScreenPC.SetActive(false);
            creditsScreenPC.SetActive(false);
        }

        else
        {
            settingScreenMobile.SetActive(true);
            startingScreenMobile.SetActive(false);
            creditsScreenMobile.SetActive(false);
        }
    }

    public void GoToStageSelectionScreen()
    {
        AudioManager.instance.Play("Selection Sound");
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            settingScreenPC.SetActive(false);
            startingScreenPC.SetActive(false);
            exitScreenPC.SetActive(false);
            creditsScreenPC.SetActive(false);
        }

        else
        {
            settingScreenMobile.SetActive(false);
            startingScreenMobile.SetActive(false);
            creditsScreenMobile.SetActive(false);
        }
    }

    public void GoToCreditsScreen()
    {
        AudioManager.instance.Play("Selection Sound");
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            settingScreenPC.SetActive(false);
            startingScreenPC.SetActive(false);
            exitScreenPC.SetActive(false);
            creditsScreenPC.SetActive(true);
        }

        else
        {
            settingScreenMobile.SetActive(false);
            startingScreenMobile.SetActive(false);
            creditsScreenMobile.SetActive(true);
        }
    }

    public void GoToLevelSelectionScreen()
    {
        AudioManager.instance.Play("Selection Sound");
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            settingScreenPC.SetActive(false);
            startingScreenPC.SetActive(false);
            exitScreenPC.SetActive(false);
            creditsScreenPC.SetActive(false);         
        }

        else
        {
            settingScreenMobile.SetActive(false);
            startingScreenMobile.SetActive(false);
            creditsScreenMobile.SetActive(false);           
        }
    }

    public void GoToStageSelection()
    {
        AudioManager.instance.Play("Selection Sound");
        SceneManager.LoadScene("StageSelection");
    }

    public void ExitApllication()
    {
        AudioManager.instance.Play("Selection Sound");
        Application.Quit();
    }

    public void ReloadScene()
    {
        AudioManager.instance.Play("Selection Sound");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
