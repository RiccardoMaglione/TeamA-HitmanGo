using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditorInternal;

public class ScroolTopDown : MonoBehaviour
{
    public bool CanScrollUp = true;
    public bool CanScrollDown = true;
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
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && CanScrollUp == true) // forward
        {
            CanScrollUp = false;
            MainCamera.transform.DOMove(FinalPosition, DurationTranslate);
            CanScrollDown = true;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f && CanScrollDown == true) // backwards
        {
            CanScrollDown = false;
            MainCamera.transform.DOMove(InitialPositionScroll, DurationTranslate);
            CanScrollUp = true;
        }
    }
    #endregion
}
