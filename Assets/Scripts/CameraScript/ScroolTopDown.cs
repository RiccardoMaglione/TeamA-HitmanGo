using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScroolTopDown : MonoBehaviour
{
    #region Variables
    [Header("Scroll Mouse - Parameters")]

    [Tooltip("The camera to which the scroll refers")]
    public GameObject MainCamera;

    Vector3 InitialPositionScroll;

    [Tooltip("The final position of camera")]
    public Vector3 FinalPosition;

    [Tooltip("Duration of camera go from initial position to final position")]
    public int DurationTranslate = 1;
    #endregion
    private void Start()
    {
        InitialPositionScroll = MainCamera.transform.position;
    }

    void Update()
    {
        ScrollMouseMoveCamera();
    }

    #region Method
    public void ScrollMouseMoveCamera()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            MainCamera.transform.DOMove(FinalPosition, DurationTranslate);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            MainCamera.transform.DOMove(InitialPositionScroll, DurationTranslate);
        }
    }
    #endregion
}
