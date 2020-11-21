using HGO.core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public GameObject gameScreenPC;
    public GameObject pauseScreeenPC;
    public GameObject gameScreenMobile;
    public GameObject pauseScreeenMobile;

    private PlayerMovement playerMovement;

    public void GoToGameScreen()
    {
        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Selection Sound");
        
        playerMovement.Enable();
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
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
        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Selection Sound");
        
        playerMovement.Disable();
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
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
        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Selection Sound");
       
        playerMovement.Enable();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToLevelSelection()
    {
        if(PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Selection Sound");
        
        AudioManager.instance.Stop("Water Sound");
        AudioManager.instance.Stop("Bird Sound");
        
        if (PlayerPrefs.GetInt("setMusic") == 1)
            AudioManager.instance.Play("Soundtrack");
        
        playerMovement.Enable();
        SceneManager.LoadScene("LevelSelection");
    }

    public void ReloadHint()
    {
        if(SceneManager.GetActiveScene().name == "Level1-1+hint")
        {
            SceneManager.LoadScene(3);
        }

        if (SceneManager.GetActiveScene().name == "Level1-2+hint")
        {
            SceneManager.LoadScene(4);
        }

        if (SceneManager.GetActiveScene().name == "Level1-3+hint")
        {
            SceneManager.LoadScene(5);
        }

        if (SceneManager.GetActiveScene().name == "Level1-4+hint")
        {
            SceneManager.LoadScene(6);
        }

        if (SceneManager.GetActiveScene().name == "Level1-5+hint")
        {
            SceneManager.LoadScene(7);
        }

        if (SceneManager.GetActiveScene().name == "Level1-6+hint")
        {
            SceneManager.LoadScene(8);
        }
    }


    void Awake()
    {
        if (!playerMovement)
            playerMovement = FindObjectOfType<PlayerMovement>();
    }
}
