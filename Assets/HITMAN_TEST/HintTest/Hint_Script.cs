using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint_Script : MonoBehaviour
{
    public GameObject Sprite;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Sprite.SetActive(true);
            gameObject.SetActive(true);
            Debug.Log("sono dentro");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Sprite.SetActive(true);
            gameObject.SetActive(true);
            Debug.Log("sono entrato");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {            
            gameObject.SetActive(false);
            Debug.Log("esco");
        }
    }


   
}
