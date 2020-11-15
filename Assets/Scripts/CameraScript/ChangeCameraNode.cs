using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using HGO.core;
public class ChangeCameraNode : MonoBehaviour
{
    public static bool CanChange = false;
    public GameObject CameraMain;
    public Vector3 newPositionCamera;
    public static Vector3 InitialPos;
    private void OnTriggerEnter(Collider other)
    {
        var character = other.gameObject.GetComponent<HGO.core.CharacterController>();

        if (character is PlayerController)
        {
            CanChange = true;
        }
    }
    void Update()
    {
        if (CanChange == true)
        {
            Change();
        }
    }

    public void Change()
    {
        
        CameraMain.transform.DOMove(newPositionCamera, 2);
        InitialPos = newPositionCamera;
    }
}
