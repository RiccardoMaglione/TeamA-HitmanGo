using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingLevel : MonoBehaviour
{
    public GameObject loadingScreen;
    // Start is called before the first frame update
    void Start()
    {
        loadingScreen.SetActive(false);
    }

    public void LoadLevel1()
    {
        StartCoroutine(LoadAsynchronously1());                   //Fa partire una coroutine che carica in modo asyncrono una determinata scena
    }
    public void LoadLevel2()
    {
        StartCoroutine(LoadAsynchronously2());                   //Fa partire una coroutine che carica in modo asyncrono una determinata scena
    }
    public void LoadLevel3()
    {
        StartCoroutine(LoadAsynchronously3());                   //Fa partire una coroutine che carica in modo asyncrono una determinata scena
    }
    public void LoadLevel4()
    {
        StartCoroutine(LoadAsynchronously4());                   //Fa partire una coroutine che carica in modo asyncrono una determinata scena
    }
    public void LoadLevel5()
    {
        StartCoroutine(LoadAsynchronously5());                   //Fa partire una coroutine che carica in modo asyncrono una determinata scena
    }
    public void LoadLevel6()
    {
        StartCoroutine(LoadAsynchronously6());                   //Fa partire una coroutine che carica in modo asyncrono una determinata scena
    }
    IEnumerator LoadAsynchronously1()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("GO 1-1");     //Fa partire l'operazione asincrona
        loadingScreen.SetActive(true);                                                //Attiva il loading screen
        while (!operation.isDone)                                                     //Mentre l'operazione non è finita
        {
            yield return null;
        }
    }
    IEnumerator LoadAsynchronously2()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("GO 1-2");     //Fa partire l'operazione asincrona
        loadingScreen.SetActive(true);                                                //Attiva il loading screen
        while (!operation.isDone)                                                     //Mentre l'operazione non è finita
        {
            yield return null;
        }
    }
    IEnumerator LoadAsynchronously3()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("GO 1-3");     //Fa partire l'operazione asincrona
        loadingScreen.SetActive(true);                                                //Attiva il loading screen
        while (!operation.isDone)                                                     //Mentre l'operazione non è finita
        {
            yield return null;
        }
    }
    IEnumerator LoadAsynchronously4()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("GO 1-4");     //Fa partire l'operazione asincrona
        loadingScreen.SetActive(true);                                                //Attiva il loading screen
        while (!operation.isDone)                                                     //Mentre l'operazione non è finita
        {
            yield return null;
        }
    }
    IEnumerator LoadAsynchronously5()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("GO 1-5");     //Fa partire l'operazione asincrona
        loadingScreen.SetActive(true);                                                //Attiva il loading screen
        while (!operation.isDone)                                                     //Mentre l'operazione non è finita
        {
            yield return null;
        }
    }
    IEnumerator LoadAsynchronously6()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("GO 1-6");     //Fa partire l'operazione asincrona
        loadingScreen.SetActive(true);                                                //Attiva il loading screen
        while (!operation.isDone)                                                     //Mentre l'operazione non è finita
        {
            yield return null;
        }
    }
}