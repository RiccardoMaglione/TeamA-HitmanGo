using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    LoadingLevel LoadLev;
    public GameObject[] IconPC = new GameObject[5];
    public GameObject[] IconMobile = new GameObject[5];

    private void Start()
    {
        LoadLev = GetComponent<LoadingLevel>();
        #region If Statement
        if (PlayerPrefs.GetInt("UnblockTwo") == 0)
        {
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                IconPC[0].SetActive(false);
            }
            if (Application.platform == RuntimePlatform.Android)
            {
                IconMobile[0].SetActive(false);
            }
        }
        else if (PlayerPrefs.GetInt("UnblockTwo") == 1)
        {
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                IconPC[0].SetActive(true);
            }
            if (Application.platform == RuntimePlatform.Android)
            {
                IconMobile[0].SetActive(true);
            }
        }

        if (PlayerPrefs.GetInt("UnblockThree") == 0)
        {
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                IconPC[1].SetActive(false);
            }
            if (Application.platform == RuntimePlatform.Android)
            {
                IconMobile[1].SetActive(false);
            }
        }
        else if (PlayerPrefs.GetInt("UnblockThree") == 1)
        {
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                IconPC[1].SetActive(true);
            }
            if (Application.platform == RuntimePlatform.Android)
            {
                IconMobile[1].SetActive(true);
            }
        }

        if (PlayerPrefs.GetInt("UnblockFour") == 0)
        {
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                IconPC[2].SetActive(false);
            }
            if (Application.platform == RuntimePlatform.Android)
            {
                IconMobile[2].SetActive(false);
            }
        }
        else if (PlayerPrefs.GetInt("UnblockFour") == 1)
        {
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                IconPC[2].SetActive(true);
            }
            if (Application.platform == RuntimePlatform.Android)
            {
                IconMobile[2].SetActive(true);
            }
        }

        if (PlayerPrefs.GetInt("UnblockFive") == 0)
        {
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                IconPC[3].SetActive(false);
            }
            if (Application.platform == RuntimePlatform.Android)
            {
                IconMobile[3].SetActive(false);
            }
        }
        else if (PlayerPrefs.GetInt("UnblockFive") == 1)
        {
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                IconPC[3].SetActive(true);
            }
            if (Application.platform == RuntimePlatform.Android)
            {
                IconMobile[3].SetActive(true);
            }
        }

        if (PlayerPrefs.GetInt("UnblockSix") == 0)
        {
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                IconPC[4].SetActive(false);
            }
            if (Application.platform == RuntimePlatform.Android)
            {
                IconMobile[4].SetActive(false);
            }
        }
        else if (PlayerPrefs.GetInt("UnblockSix") == 1)
        {
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                IconPC[4].SetActive(true);
            }
            if (Application.platform == RuntimePlatform.Android)
            {
                IconMobile[4].SetActive(true);
            }
        }
        #endregion
    }

    public void GoToLevelSelection()
    {
        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Selection Sound");
        
        SceneManager.LoadScene("LevelSelection");        
    }

    public void GoToStartingScreen()
    {
        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Selection Sound");
        
        SceneManager.LoadScene("Menu");
    }

    public void GoToStageSelection()
    {
        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Selection Sound");
        
        SceneManager.LoadScene("StageSelection");
    }

    public void SceneLevel1()
    {
        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Selection Sound");
        
        AudioManager.instance.Stop("Soundtrack");
        
        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Bird Sound");
        
        //SceneManager.LoadScene("GO 1-1");
        LoadLev.LoadLevel1();
    }

    public void SceneLevel2()
    {
        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Selection Sound");
        
        AudioManager.instance.Stop("Soundtrack");
        
        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Bird Sound");
        
        //SceneManager.LoadScene("GO 1-2");
        LoadLev.LoadLevel2();
    }

    public void SceneLevel3()
    {
        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Selection Sound");
        
        AudioManager.instance.Stop("Soundtrack");

        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Bird Sound");
        
        //SceneManager.LoadScene("GO 1-3");
        LoadLev.LoadLevel3();
    }

    public void SceneLevel4()
    {
        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Selection Sound");
       
        AudioManager.instance.Stop("Soundtrack");

        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Bird Sound");
       
        //SceneManager.LoadScene("GO 1-4");
        LoadLev.LoadLevel4();
    }

    public void SceneLevel5()
    {
        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Selection Sound");
       
        AudioManager.instance.Stop("Soundtrack");

        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Bird Sound");
        
        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Water Sound");
       
        //SceneManager.LoadScene("GO 1-5");
        LoadLev.LoadLevel5();
    }

    public void SceneLevel6()
    {
        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Selection Sound");
        
        AudioManager.instance.Stop("Soundtrack");

        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Bird Sound");
        
        //SceneManager.LoadScene("GO 1-6");
        LoadLev.LoadLevel6();
    }
}
