using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactive_Hint : MonoBehaviour
{
    public GameObject[] Hints;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            for (int i = 0; i < Hints.Length; i++)
            {
                Hints[i].SetActive(false);
            }
        }
       
    }
}
