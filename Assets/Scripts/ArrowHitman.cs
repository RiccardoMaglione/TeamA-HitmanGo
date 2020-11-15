using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HGO.core;

public class ArrowHitman : MonoBehaviour
{
    public GameObject[] Arrow;

    private void OnTriggerEnter(Collider other)
    {
        var character = other.gameObject.GetComponent<HGO.core.CharacterController>();

        if (character is PlayerController)
        {
            for (int i = 0; i < Arrow.Length; i++)
            {
                Arrow[i].SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var character = other.gameObject.GetComponent<HGO.core.CharacterController>();

        if (character is PlayerController)
        {
            for (int i = 0; i < Arrow.Length; i++)
            {
                Arrow[i].SetActive(false);
            }
        }
    }
}
