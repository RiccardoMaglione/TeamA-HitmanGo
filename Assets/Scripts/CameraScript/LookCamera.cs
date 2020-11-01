using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LookCamera : MonoBehaviour
{
    #region Variables
    [Header("DoLookAt Parameters")]

    [Tooltip("The camera that the player follow")]
    public GameObject MainCamera;

    [Tooltip("Is a delay before the forward of this object reaches destination")]
    public float DelayDuration = 0;
    #endregion

    void Update()
    {
        transform.DOLookAt(MainCamera.transform.position, DelayDuration, AxisConstraint.Y);         //A simple look at with DoTween with duration and axis contraint on axis Y
    }
}
