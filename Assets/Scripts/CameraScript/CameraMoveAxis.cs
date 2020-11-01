using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[System.Serializable]
public struct AnglesDegrees
{
    [Header("Vertical Movement - Horizontal Rotation")]
    [Tooltip("Indicates minimum of the angle in degrees - Movement from mouse to down")]
    public float MinX;
    [Tooltip("Indicates maximum of the angle in degrees - Movement from mouse to up")]
    public float MaxX;

    [Header("Horizontal Movement - Vertical Rotation")]
    [Tooltip("Indicates minimum of the angle in degrees - Movement from mouse to left")]
    public float MinY;
    [Tooltip("Indicates maximum of the angle in degrees - Movement from mouse to right")]
    public float MaxY;
}
public class CameraMoveAxis : MonoBehaviour
{
    [Header("Struct AnglesDegrees")]
    public AnglesDegrees AD;
    #region Variables
    [Header("Camera Parameters")]
    [Tooltip("Rappresent the center of screen")]
    public GameObject Target;
    Vector3 InitialPosition;
    Quaternion InitialRotation;
    [Tooltip("Indicates velocity of rotation")]
    public float TurnSpeed = 3.0f;
    float RotationHorizontal;
    float RotationVertical;
    [Tooltip("Indicate if ray of mouse is on player or not, for the start of camera's movement")]
    bool CanMove = true;
    [Tooltip("Duration of DoMove for return camera in initial position")]
    public float DurationInitPos = 0;
    [Tooltip("Duration of DoRotation for return camera in initial rotation")]
    public float DurationInitRot = 0;
    #endregion

    private void Start()
    {
        InitializeTransform();
    }

    private void Update()
    {
        transform.LookAt(Target.transform);

        if (Input.GetMouseButtonDown(0))
        {
            DetectCanMove();
        }
        if (Input.GetMouseButton(0) && CanMove == true)
        {
            MoveCamera();
        }
        if (Input.GetMouseButtonUp(0))
        {
            ReturnInitial();
        }
    }

    #region Method
    public void InitializeTransform()
    {
        InitialPosition = transform.position;
        InitialRotation = transform.rotation;
    }
    public void DetectCanMove()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Player")
                {
                    CanMove = false;
                }
                else
                {
                    CanMove = true;
                }
            }
        }
        else
        {
            CanMove = true;
        }
    }
    public void MoveCamera()
    {
        RotationHorizontal = Input.GetAxis("Mouse X") * TurnSpeed;
        RotationVertical = Input.GetAxis("Mouse Y") * TurnSpeed;

        // Calculate the current angle in degrees (Not very reliable using Euler angles in all situations. Keep this in mind!)
        float verticalAngle = transform.localEulerAngles.x > 180 ? transform.localEulerAngles.x - 360 : transform.localEulerAngles.x;
        float horizontalAngle = transform.localEulerAngles.y > 180 ? transform.localEulerAngles.y - 360 : transform.localEulerAngles.y;

        // Set verticalRotation to zero if min or max value is reached
        if (verticalAngle > AD.MaxX && RotationVertical > 0) RotationVertical = 0;
        else if (verticalAngle < AD.MinX && RotationVertical < 0) RotationVertical = 0;

        if (horizontalAngle > AD.MaxY && RotationHorizontal > 0) RotationHorizontal = 0;
        else if (horizontalAngle < AD.MinY && RotationHorizontal < 0) RotationHorizontal = 0;


        // Rotate the camera
        transform.RotateAround(Target.transform.position, Vector3.up, RotationHorizontal);
        transform.RotateAround(Target.transform.position, transform.right, RotationVertical);

    }
    public void ReturnInitial()
    {
        transform.DOMove(InitialPosition, DurationInitPos);
        transform.DORotateQuaternion(InitialRotation, DurationInitRot);
    }
    #endregion
}