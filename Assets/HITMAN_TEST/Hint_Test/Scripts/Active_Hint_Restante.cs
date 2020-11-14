using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_Hint_Restante : MonoBehaviour
{
    public GameObject HINT;
    public GameObject Interruttori_OFF;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            HINT.SetActive(true);
            Interruttori_OFF.SetActive(false);
        }
            
    }
}
