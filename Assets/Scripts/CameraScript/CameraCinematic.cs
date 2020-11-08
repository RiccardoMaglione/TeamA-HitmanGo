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

    void Start()
    {
        CameraPosition = new Vector3[ObjectPosition.Length];
        for (int i = 0; i < ObjectPosition.Length; i++)
        {
            CameraPosition[i] = ObjectPosition[i].transform.position;
        }
        MainCamera.transform.DOPath(CameraPosition, 30, PathType.CatmullRom, PathMode.Full3D, 10, Color.black).OnWaypointChange(MyCallback).id=1;
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //}
        if (Input.GetMouseButtonDown(0)) //Se schiaccio la camera va nell'ultima posizione assegnata
        {
            //DOTween.KillAll();
            DOTween.Kill(1);
            MainCamera.transform.DOMove(CameraPosition[CameraPosition.Length - 1], 1);
        }
       // MainCamera.transform.DOLookAt(Target.transform.position, 1); 
    }

    void MyCallback(int waypointIndex)
    {
        Debug.Log("Waypoint index changed to " + waypointIndex);
        if (waypointIndex >= 3)
        {
            DOTween.timeScale = 30;
        }
    }
}
