using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerPC : MonoBehaviour
{
    public PlayerMovementPM PM;

    private void Awake()
    {
        PM = GetComponent<PlayerMovementPM>();
    }
}