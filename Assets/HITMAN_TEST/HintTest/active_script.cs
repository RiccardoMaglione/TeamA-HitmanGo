using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class active_script : MonoBehaviour
{
    public GameObject Triggers;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Triggers.SetActive(true);
            gameObject.SetActive(true);
            
        }
    }
}
