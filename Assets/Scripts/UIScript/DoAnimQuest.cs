using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoAnimQuest : MonoBehaviour
{
    public GameObject[] PointObject;
    public Vector3[] PointVector;
    public float SpeedTime;

    private void Start()
    {
        for (int i = 0; i < PointObject.Length; i++)
        {
            PointVector[i] = PointObject[i].transform.position;
        }
        transform.DOPath(PointVector, 30, PathType.CatmullRom, PathMode.Full3D, 10, Color.black).OnWaypointChange(MyCallback);
        DOTween.timeScale = SpeedTime;
    }

    void MyCallback(int waypointIndex)
    {
        if (waypointIndex >= PointVector.Length - 1)
        {
            DOTween.timeScale = 1;
        }
    }
}