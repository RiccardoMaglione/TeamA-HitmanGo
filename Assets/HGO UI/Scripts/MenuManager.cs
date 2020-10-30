using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject startingScreen;
    public GameObject exitScreen;
    public GameObject settingScreen;
    public GameObject stageSelectionScreen;
    public GameObject creditsScreen;
    public GameObject gameScreen;
    public GameObject pauseScreeen;

    public void GoToExitScreen()
    {
        exitScreen.SetActive(true);
        startingScreen.SetActive(false);
        settingScreen.SetActive(false);
        stageSelectionScreen.SetActive(false);
        creditsScreen.SetActive(false);
        gameScreen.SetActive(false);
        pauseScreeen.SetActive(false);
    }

    public void GoToStartingScreen()
    {
        startingScreen.SetActive(true);
        exitScreen.SetActive(false);
        settingScreen.SetActive(false);
        stageSelectionScreen.SetActive(false);
        creditsScreen.SetActive(false);
        gameScreen.SetActive(false);
        pauseScreeen.SetActive(false);
    }

    public void GoToSettingScreen()
    {
        settingScreen.SetActive(true);
        startingScreen.SetActive(false);
        exitScreen.SetActive(false);
        stageSelectionScreen.SetActive(false);
        creditsScreen.SetActive(false);
        gameScreen.SetActive(false);
        pauseScreeen.SetActive(false);
    }

    public void GoToStageSelectionScreen()
    {
        stageSelectionScreen.SetActive(true);
        settingScreen.SetActive(false);
        startingScreen.SetActive(false);
        exitScreen.SetActive(false);
        creditsScreen.SetActive(false);
        gameScreen.SetActive(false);
        pauseScreeen.SetActive(false);
    }

    public void GoToCreditsScreen()
    {
        stageSelectionScreen.SetActive(false);
        settingScreen.SetActive(false);
        startingScreen.SetActive(false);
        exitScreen.SetActive(false);
        creditsScreen.SetActive(true);
        gameScreen.SetActive(false);
        pauseScreeen.SetActive(false);
    }

    public void GoToGameScreen()
    {
        gameScreen.SetActive(true);
        exitScreen.SetActive(false);
        startingScreen.SetActive(false);
        settingScreen.SetActive(false);
        stageSelectionScreen.SetActive(false);
        creditsScreen.SetActive(false);
        pauseScreeen.SetActive(false);      
    }

    public void GoToPauseScreen()
    {
        pauseScreeen.SetActive(true);
        exitScreen.SetActive(false);
        startingScreen.SetActive(false);
        settingScreen.SetActive(false);
        stageSelectionScreen.SetActive(false);
        creditsScreen.SetActive(false);
        gameScreen.SetActive(false);     
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
