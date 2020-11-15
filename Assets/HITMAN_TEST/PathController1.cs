using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PathController1 : MonoBehaviour
{
    public GameObject Path1;
    public GameObject Path2;

    // Start is called before the first frame update
    void Start()
    {
        
            Path1.SetActive(true);
            Path2.SetActive(false);

            StartCoroutine(Percorso2());
        
       
    }

    private IEnumerator Percorso2()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        Path2.SetActive(true);

        Debug.Log("DioPorco");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Level1");
        }
    }

}

