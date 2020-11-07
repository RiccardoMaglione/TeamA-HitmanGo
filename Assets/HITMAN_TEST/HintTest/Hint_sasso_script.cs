using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint_sasso_script : MonoBehaviour
{
    public GameObject Sprite;
    public GameObject Triggers;

    private ThrowItem Script_Sasso;


    private void Start()
    {
        Script_Sasso = GameObject.FindObjectOfType<ThrowItem>();

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            //Sprite.SetActive(true);
            gameObject.SetActive(true);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Sprite.SetActive(true);
            gameObject.SetActive(true);
            //Triggers.SetActive(true);
            StartCoroutine(Attesa());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") 
        {
            gameObject.SetActive(false);
            
        }
    }

    private IEnumerator Attesa()
    {
        yield return new WaitForSecondsRealtime(3);
        Triggers.SetActive(true);
        Sprite.SetActive(true);
    }

}
