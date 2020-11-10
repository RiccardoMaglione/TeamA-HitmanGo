using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public void GoToLevelSelection()
    {
        FindObjectOfType<AudioManager>().Play("Selection Sound");
        SceneManager.LoadScene("LevelSelection");        
    }

    public void GoToStartingScreen()
    {
        FindObjectOfType<AudioManager>().Play("Selection Sound");
        SceneManager.LoadScene("Menu");
    }

    public void GoToStageSelection()
    {
        FindObjectOfType<AudioManager>().Play("Selection Sound");
        SceneManager.LoadScene("StageSelection");
    }

    public void SceneLevel1()
    {
        FindObjectOfType<AudioManager>().Play("Selection Sound");
        FindObjectOfType<AudioManager>().Stop("Soundtrack");
        FindObjectOfType<AudioManager>().Play("Bird Sound");
        SceneManager.LoadScene("GO 1-1");
    }

    public void SceneLevel2()
    {
        FindObjectOfType<AudioManager>().Play("Selection Sound");
        FindObjectOfType<AudioManager>().Stop("Soundtrack");
        FindObjectOfType<AudioManager>().Play("Bird Sound");
        SceneManager.LoadScene("GO 1-2");
    }

    public void SceneLevel3()
    {
        FindObjectOfType<AudioManager>().Play("Selection Sound");
        FindObjectOfType<AudioManager>().Stop("Soundtrack");
        FindObjectOfType<AudioManager>().Play("Bird Sound");
        SceneManager.LoadScene("GO 1-3");
    }

    public void SceneLevel4()
    {
        FindObjectOfType<AudioManager>().Play("Selection Sound");
        FindObjectOfType<AudioManager>().Stop("Soundtrack");
        FindObjectOfType<AudioManager>().Play("Bird Sound");
        SceneManager.LoadScene("GO 1-4");
    }

    public void SceneLevel5()
    {
        FindObjectOfType<AudioManager>().Play("Selection Sound");
        FindObjectOfType<AudioManager>().Stop("Soundtrack");
        FindObjectOfType<AudioManager>().Play("Bird Sound");
        FindObjectOfType<AudioManager>().Play("Water Sound");
        SceneManager.LoadScene("GO 1-5");
    }

    public void SceneLevel6()
    {
        FindObjectOfType<AudioManager>().Play("Selection Sound");
        FindObjectOfType<AudioManager>().Stop("Soundtrack");
        FindObjectOfType<AudioManager>().Play("Bird Sound");
        SceneManager.LoadScene("GO 1-6");
    }
}
