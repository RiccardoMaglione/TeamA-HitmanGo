using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public void GoToLevelSelection()
    {
        SceneManager.LoadScene("LevelSelection");
    }
    public void SceneLevel1()
    {
        SceneManager.LoadScene("GO 1-1");
    }
    public void SceneLevel2()
    {
        SceneManager.LoadScene("GO 1-2");
    }
    public void SceneLevel3()
    {
        SceneManager.LoadScene("GO 1-3");
    }
    public void SceneLevel4()
    {
        SceneManager.LoadScene("GO 1-4");
    }
    public void SceneLevel5()
    {
        SceneManager.LoadScene("GO 1-5");
    }
    public void SceneLevel6()
    {
        SceneManager.LoadScene("GO 1-6");
    }
}
