using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HeartBeat : MonoBehaviour
{
    #region Variables
    [Header("Heart Beat parameters - Coordinates Vector3")]
    [Tooltip("X axis scale")]
    public float xVec3;
    [Tooltip("Y axis scale")]
    public float yVec3;
    [Tooltip("Z axis scale")]
    public float zVec3;
    [Header("Heart Beat parameters - Other")]
    [Tooltip("Wait time between each heart beat")]
    public float WaitTime;
    [Range(0,1)]
    [Tooltip("Duration of heart beat")]
    public float Duration;
    [Tooltip("Number of loops")]
    public int NumLoops;
    [Tooltip("If true = yoyo --> Animation do forward and backward\nElse false = restart --> Animation do only forward")]
    public bool isYoyo = true;
    #endregion
    void Start()
    {
        StartCoroutine(HeartBeatGo());
    }

    public IEnumerator HeartBeatGo()
    {
        while(true)
        {
            yield return new WaitForSeconds(WaitTime);
            if(isYoyo == true)
            {
                transform.DOPunchScale(new Vector3(xVec3, yVec3, zVec3), Duration).SetLoops(NumLoops, LoopType.Yoyo);
            }
            else
            {
                transform.DOPunchScale(new Vector3(xVec3, yVec3, zVec3), Duration).SetLoops(NumLoops, LoopType.Restart);
            }
        }
    }
}
