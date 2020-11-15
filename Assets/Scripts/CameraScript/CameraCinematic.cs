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

    public bool PathCatmullRom = true;
    public bool PathLinear = false;


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
            DOTween.timeScale = SpeedInitial;
            CanStart = false;

            if (PathCatmullRom == true)
            {
                PathLinear = false;
                MainCamera.transform.DOPath(CameraPosition, 30, PathType.CatmullRom, PathMode.Full3D, 10, Color.black).OnWaypointChange(MyCallback).id = 1;
            }
            if (PathLinear == true)
            {
                PathCatmullRom = false;
                MainCamera.transform.DOPath(CameraPosition, 30, PathType.Linear, PathMode.Full3D, 10, Color.black).OnWaypointChange(MyCallback).id = 1;
            }

        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            //DOTween.Kill(1);
            DOTween.KillAll();
            MainCamera.transform.DOMove(CameraPosition[CameraPosition.Length - 1], 1);
            MainCamera.transform.DORotate(RotCamera[CameraPosition.Length - 1], DurationRotation);
            DOTween.timeScale = 1;
            StartCoroutine(ActiveScript());
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
            if (ActivateCamereDevice.PCVersion == true)
            {
                MainCamera.GetComponent<ScroolTopDown>().enabled = true;
                MainCamera.GetComponent<CameraMoveAxis>().enabled = true;
            }
            if (ActivateCamereDevice.MobileVersion == true)
            {
                MainCamera.GetComponent<CameraAndroidAxis>().enabled = true;
            }
            DOTween.timeScale = 1;
        }
    }
    public IEnumerator ActiveScript()
    {
        yield return new WaitForSeconds(2.25f);
        if(ActivateCamereDevice.PCVersion == true)
        {
            MainCamera.GetComponent<ScroolTopDown>().enabled = true;
            MainCamera.GetComponent<CameraMoveAxis>().enabled = true;
        }
        if (ActivateCamereDevice.MobileVersion == true)
        {
            MainCamera.GetComponent<CameraAndroidAxis>().enabled = true;
        }
    }
}
