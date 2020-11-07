using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close_All : MonoBehaviour
{
    public GameObject Triggers;


    private void OnTriggerEnter(Collider other)
    {
        Triggers.SetActive(false);
    }
}
