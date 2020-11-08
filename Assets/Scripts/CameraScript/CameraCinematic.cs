using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraCinematic : MonoBehaviour
{
    [Tooltip("Is possible to be center of camera, or player, or a generic targer")]
    public GameObject Target;
    public GameObject MainCamera;
    [Tooltip("Array of position of cinematic")]
    public GameObject[] ObjectPosition;
    public Vector3[] CameraPosition;

    public object Kill;

    public static bool CanTarget;
    public bool CanStart = false;

    public int NumWaypoint = 99;
    public float SpeedMultiplier = 1;

    void Start()
    {
        CanStart = false;
        CanTarget = false;
        CameraPosition = new Vector3[ObjectPosition.Length];
        for (int i = 0; i < ObjectPosition.Length; i++)
        {
            CameraPosition[i] = ObjectPosition[i].transform.position;
        }
        CanStart = true;
    }

    void Update()
    {
        if (transform.position == CameraPosition[CameraPosition.Length - 1])
        {
            CanTarget = true;
        }
        if (CanStart == true)
        {
            CanStart = false;
            MainCamera.transform.DOPath(CameraPosition, 30, PathType.CatmullRom, PathMode.Full3D, 10, Color.black).OnWaypointChange(MyCallback);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            DOTween.KillAll();
            MainCamera.transform.DOMove(CameraPosition[CameraPosition.Length - 1], 1);
        }
        // MainCamera.transform.DOLookAt(Target.transform.position, 1); 
    }

    void MyCallback(int waypointIndex)
    {
        Debug.Log("Waypoint index changed to " + waypointIndex);
        if (waypointIndex >= NumWaypoint)
        {
            DOTween.timeScale = SpeedMultiplier;
        }
    }
}
