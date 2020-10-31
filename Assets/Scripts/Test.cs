using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public GameObject nave;
    public GameObject esplosione;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            nave.SetActive(false);
            esplosione.SetActive(true);
        }

        else if (Input.GetKeyUp(KeyCode.Space))
        {
            nave.SetActive(true);
            esplosione.SetActive(false);

        }
    }

    
}
