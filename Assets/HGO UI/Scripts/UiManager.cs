using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public GameObject gameScreenPC;
    public GameObject pauseScreeenPC;
    public GameObject gameScreenMobile;
    public GameObject pauseScreeenMobile;

    public void GoToGameScreen()
    {
        Time.timeScale = 1;
        if (Application.platform == RuntimePlatform.WindowsPlayer)
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
        Time.timeScale = 0f;
        if (Application.platform == RuntimePlatform.WindowsPlayer)
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
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToLevelSelection()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LevelSelection");
    }
}
