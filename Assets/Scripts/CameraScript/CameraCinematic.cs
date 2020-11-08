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
    public Vector3[] RotCamera;
    public Vector3 RotDef;
    public object Kill;

    public static bool CanTarget;
    public bool CanStart = false;

    public int NumWaypoint = 99;
    public float SpeedMultiplier = 1;
    public float SpeedInitial = 1;
    public float DurationRotation = 5;


    void Start()
    {
        DOTween.timeScale = SpeedInitial;
        CanStart = false;
        CanTarget = false;
        CameraPosition = new Vector3[ObjectPosition.Length];
        for (int i = 0; i < ObjectPosition.Length; i++)
        {
            CameraPosition[i] = ObjectPosition[i].transform.position;
            RotCamera[i] = ObjectPosition[i].transform.eulerAngles;
        }
        CanStart = true;
    }

    void Update()
    {
        if (CanStart == true)
        {
            CanStart = false;

            MainCamera.transform.DOPath(CameraPosition, 30, PathType.CatmullRom, PathMode.Full3D, 10, Color.black).OnWaypointChange(MyCallback).id = 1;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            //DOTween.Kill(1);
            DOTween.KillAll();
            MainCamera.transform.DOMove(CameraPosition[CameraPosition.Length - 1], 1);
            MainCamera.transform.DORotate(RotCamera[CameraPosition.Length - 1], DurationRotation);
            DOTween.timeScale = 1;
        }
    }

    void MyCallback(int waypointIndex)
    {
        if (waypointIndex + 1 <= CameraPosition.Length - 1)
        {
            RotDef = RotCamera[waypointIndex + 1];
            MainCamera.transform.DORotate(RotDef, DurationRotation);
        }
        Debug.Log("Waypoint index changed to " + waypointIndex);
        Debug.Log("cam index changed to " + RotDef);
        if (waypointIndex >= NumWaypoint)
        {
            DOTween.timeScale = SpeedMultiplier;
        }
        if (waypointIndex >= CameraPosition.Length - 2)
        {
            CanTarget = true;
        }
        if (waypointIndex >= CameraPosition.Length - 1)
        {
            MainCamera.GetComponent<ScroolTopDown>().enabled = true;
            MainCamera.GetComponent<CameraMoveAxis>().enabled = true;
            DOTween.timeScale = 1;
        }
    }
}
