using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PathController2 : MonoBehaviour
{
    public GameObject Path1;
    public GameObject Path2;
    public GameObject Path3;
    public GameObject Path4;
    public GameObject Path5;

    // Start is called before the first frame update
    void Start()
    {
        
        
            Path1.SetActive(true);
            Path2.SetActive(false);
            Path3.SetActive(false);
            Path4.SetActive(false);
            Path5.SetActive(false);

            StartCoroutine(Percorso2());
        
       
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
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Level2");
        }
    }

}
