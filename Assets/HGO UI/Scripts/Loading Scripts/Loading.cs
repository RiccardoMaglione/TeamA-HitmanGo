using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public GameObject loadingScreen;
    CompleteQuestLevel CQL;
    // Start is called before the first frame update
    void Start()
    {
        loadingScreen.SetActive(false);
    }

    public void LoadLevel()
    {
        StartCoroutine(LoadAsynchronously());                   //Fa partire una coroutine che carica in modo asyncrono una determinata scena
    }
    IEnumerator LoadAsynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("LevelSelection");     //Fa partire l'operazione asincrona
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            CQL.EndLevelScreenPc.SetActive(false);
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            CQL.EndLevelScreenMobile.SetActive(false);
        }
        loadingScreen.SetActive(true);                                          //Attiva il loading screen
        while (!operation.isDone)                                               //Mentre l'operazione non è finita
        {
            yield return null;
        }
    }
}
