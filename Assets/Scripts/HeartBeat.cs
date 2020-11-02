using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HeartBeat : MonoBehaviour
{
    #region Variables
    [Header("Heart Beat parameters - Coordinates Vector3")]
    [Tooltip("X axis scale")]
    public float xVec3 = 0.5f;
    [Tooltip("Y axis scale")]
    public float yVec3 = 0.5f;
    [Tooltip("Z axis scale")]
    public float zVec3 = 0.5f;
    [Header("Heart Beat parameters - Other")]
    [Tooltip("Wait time between each heart beat")]
    public float WaitTime = 0.5f;
    [Range(0,1)]
    [Tooltip("Duration of heart beat")]
    public float Duration = 0.5f;
    [Tooltip("Number of loops")]
    public int NumLoops = 2;
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
            yield return new WaitForSeconds(5);
            if(isYoyo == true)
            {
                transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 0.5f).SetLoops(2, LoopType.Yoyo);
            }
            else
            {
                transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 0.5f).SetLoops(2, LoopType.Restart);
            }
        }
    }
}
