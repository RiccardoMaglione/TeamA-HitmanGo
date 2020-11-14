using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactive_Rock : MonoBehaviour
{
    public GameObject[] Hints;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Rock")
        {
            for (int i = 0; i < Hints.Length; i++)
            {
                Hints[i].SetActive(false);
            }
        }                
    }
}
