using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using HGO.core;
public class ChangeCameraNode : MonoBehaviour
{
    public  bool CanChange = false;
    public GameObject CameraMain;
    public Vector3 newPositionCamera;
    public  Vector3 InitialPos;
    private void OnTriggerEnter(Collider other)
    {
        var character = other.gameObject.GetComponent<HGO.core.CharacterController>();
        print("Giusto"+newPositionCamera);

        if (character is PlayerController)
        {
            print("Giusto1"+newPositionCamera);
            CanChange = true;
        }
    }
    void Update()
    {
        if (CanChange == true)
        {
            print("Giusto2"+newPositionCamera);
            Change();
        }
    }

    public void Change()
    {
        print("Giusto3"+newPositionCamera);
        CameraMain.transform.DOMove(newPositionCamera, 2);
        //CameraMain.transform.position = newPositionCamera;
        InitialPos = newPositionCamera;
        CameraMoveAxis.InitialPosition = InitialPos;
    }
    private void OnTriggerExit(Collider other)
    {
        var character = other.gameObject.GetComponent<HGO.core.CharacterController>();

        if (character is PlayerController)
        {
            CanChange = false;
        }
    }
}
