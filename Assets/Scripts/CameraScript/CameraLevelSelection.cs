using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[System.Serializable]
public class Limit
{
    public float MinX;
    public float MaxX;
    public float MinZ;
    public float MaxZ;
}
public class CameraLevelSelection : MonoBehaviour
{
    public Limit LimitScreen;
    public GameObject MainCamera;
    public float SpeedAxisX = 1;
    public float SpeedAxisY = 1;
    [Tooltip("Snap of zoom when scroll wheel of mouse")]
    public float SnapZoom = 1;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MainCamera.transform.position = transform.position;
            MainCamera.transform.position += new Vector3(Input.GetAxis("Mouse X") * SpeedAxisX, 0, Input.GetAxis("Mouse Y") * SpeedAxisY);
            MainCamera.transform.position = new Vector3(Mathf.Clamp(MainCamera.transform.position.x, LimitScreen.MinX, LimitScreen.MaxX), MainCamera.transform.position.y, Mathf.Clamp(MainCamera.transform.position.z, LimitScreen.MinZ, LimitScreen.MaxZ));
            transform.position = MainCamera.transform.position;
        }
        ZoomMouseSnap();
        if (Application.platform == RuntimePlatform.Android)
        {
            ZoomSmoothMobile();
        }
    }

    public void ZoomMouseSnap()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && transform.position.y > 5)
        {
            transform.position -= new Vector3(0, SnapZoom, 0);
            if (transform.position.y < 5)
            {
                transform.position = new Vector3(transform.position.x, 5, transform.position.z);
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && transform.position.y < 40)
        {
            transform.position += new Vector3(0, SnapZoom, 0);
            if (transform.position.y > 40)
            {
                transform.position = new Vector3(transform.position.x, 40, transform.position.z);
            }
        }
    }
    public void ZoomSmoothMobile()
    {
        if (Input.touchCount >= 2)
        {
            Vector2 touch0, touch1;
            float distance1;
            touch0 = Input.GetTouch(0).position;
            touch1 = Input.GetTouch(1).position;
            distance1 = Vector2.Distance(touch0, touch1);
            float distance2;
            touch0 = Input.GetTouch(0).position;
            touch1 = Input.GetTouch(1).position;
            distance2 = Vector2.Distance(touch0, touch1);

            if ((distance1 + distance2) > 1 && transform.position.y > 5)
            {
                transform.DOMove(transform.position + new Vector3(0, SnapZoom, 0), 1);
                if (transform.position.y < 5)
                {
                    transform.position = new Vector3(transform.position.x, 5, transform.position.z);
                }
            }
            if ((distance1 + distance2) < 0.5f && transform.position.y < 40)
            {
                transform.DOMove(transform.position - new Vector3(0, SnapZoom, 0), 1);
                if (transform.position.y > 40)
                {
                    transform.position = new Vector3(transform.position.x, 40, transform.position.z);
                }
            }
        }
    }
}