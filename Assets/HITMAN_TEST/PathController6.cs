using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PathController6 : MonoBehaviour
{
    public GameObject Path1;
    public GameObject Path2;
    public GameObject Path3;
    public GameObject Path4;
    public GameObject Path5;
    public GameObject Path6;
    public GameObject Path7;
    public GameObject Path8;
    public GameObject Path9;

    // Start is called before the first frame update
    void Start()
    {
        Path1.SetActive(true);
        Path2.SetActive(false);
        Path3.SetActive(false);
        Path4.SetActive(false);
        Path5.SetActive(false);
        Path6.SetActive(false);
        Path7.SetActive(false);
        Path8.SetActive(false);
        Path9.SetActive(false);

        StartCoroutine(Percorso2());

        /*Invoke("Percorso2", 0.2f);
        Invoke("Percorso3", 0.3f);
        Invoke("Percorso4", 0.4f);
        Invoke("Percorso5", 0.5f);
        Invoke("Percorso6", 0.6f);
        Invoke("Percorso7", 0.7f);
        Invoke("Percorso8", 0.8f);
        Invoke("Percorso9", 0.9f);*/
    }

    private IEnumerator Percorso2()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        Path2.SetActive(true);
        
        StartCoroutine(Percorso3());

        Debug.Log("DioPorco");
    }

    private IEnumerator Percorso3()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        Path3.SetActive(true);
        
        StartCoroutine(Percorso4());
    }

    private IEnumerator Percorso4()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        Path4.SetActive(true);

        StartCoroutine(Percorso5());
    }

    private IEnumerator Percorso5()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        Path5.SetActive(true);

        StartCoroutine(Percorso6());
    }

    private IEnumerator Percorso6()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        Path6.SetActive(true);

        StartCoroutine(Percorso7());

    }

    private IEnumerator Percorso7()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        Path7.SetActive(true);

        StartCoroutine(Percorso8());
    }

    private IEnumerator Percorso8()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        Path8.SetActive(true);

        StartCoroutine(Percorso9());
    }

    private IEnumerator Percorso9()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        Path9.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Level6");
        }
    }

}
