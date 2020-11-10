using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public void GoToLevelSelection()
    {
        AudioManager.instance.Play("Selection Sound");
        SceneManager.LoadScene("LevelSelection");        
    }

    public void GoToStartingScreen()
    {
        AudioManager.instance.Play("Selection Sound");
        SceneManager.LoadScene("Menu");
    }

    public void GoToStageSelection()
    {
        AudioManager.instance.Play("Selection Sound");
        SceneManager.LoadScene("StageSelection");
    }

    public void SceneLevel1()
    {
        AudioManager.instance.Play("Selection Sound");
        AudioManager.instance.Stop("Soundtrack");
        AudioManager.instance.Play("Bird Sound");
        SceneManager.LoadScene("GO 1-1");
    }

    public void SceneLevel2()
    {
        AudioManager.instance.Play("Selection Sound");
        AudioManager.instance.Stop("Soundtrack");
        AudioManager.instance.Play("Bird Sound");
        SceneManager.LoadScene("GO 1-2");
    }

    public void SceneLevel3()
    {
        AudioManager.instance.Play("Selection Sound");
        AudioManager.instance.Stop("Soundtrack");
        AudioManager.instance.Play("Bird Sound");
        SceneManager.LoadScene("GO 1-3");
    }

    public void SceneLevel4()
    {
       AudioManager.instance.Play("Selection Sound");
       AudioManager.instance.Stop("Soundtrack");
       AudioManager.instance.Play("Bird Sound");
       SceneManager.LoadScene("GO 1-4");
    }

    public void SceneLevel5()
    {
       AudioManager.instance.Play("Selection Sound");
       AudioManager.instance.Stop("Soundtrack");
       AudioManager.instance.Play("Bird Sound");
       AudioManager.instance.Play("Water Sound");
       SceneManager.LoadScene("GO 1-5");
    }

    public void SceneLevel6()
    {
        AudioManager.instance.Play("Selection Sound");
        AudioManager.instance.Stop("Soundtrack");
        AudioManager.instance.Play("Bird Sound");
        SceneManager.LoadScene("GO 1-6");
    }
}
