using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint_Script : MonoBehaviour
{
    public GameObject Sprite;
    public GameObject Trigger_Spento;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Sprite.SetActive(true);
            gameObject.SetActive(true);
           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Sprite.SetActive(true);
            gameObject.SetActive(true);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Trigger_Spento.SetActive(true);
            gameObject.SetActive(false);
            
            
        }
    }


   
}
