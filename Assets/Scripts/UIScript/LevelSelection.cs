using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
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
        
        SceneManager.LoadScene("GO 1-1");
    }

    public void SceneLevel2()
    {
        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Selection Sound");
        
        AudioManager.instance.Stop("Soundtrack");
        
        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Bird Sound");
        
        SceneManager.LoadScene("GO 1-2");
    }

    public void SceneLevel3()
    {
        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Selection Sound");
        
        AudioManager.instance.Stop("Soundtrack");

        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Bird Sound");
        
        SceneManager.LoadScene("GO 1-3");
    }

    public void SceneLevel4()
    {
        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Selection Sound");
       
        AudioManager.instance.Stop("Soundtrack");

        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Bird Sound");
       
        SceneManager.LoadScene("GO 1-4");
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
       
        SceneManager.LoadScene("GO 1-5");
    }

    public void SceneLevel6()
    {
        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Selection Sound");
        
        AudioManager.instance.Stop("Soundtrack");

        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Bird Sound");
        
        SceneManager.LoadScene("GO 1-6");
    }
}
