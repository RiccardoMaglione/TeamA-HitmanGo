using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomImageDef : MonoBehaviour
{
    public float zoomOutMin = 1;
    public float zoomOutMax = 8;
    public GameObject ImageMap;

    private void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * 0.01f);
        }
        zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    void zoom(float increment)
    {
        Vector3 newScale = new Vector3();
        newScale.x = Mathf.Clamp(ImageMap.transform.localScale.x - increment, zoomOutMin, zoomOutMax);
        newScale.y = Mathf.Clamp(ImageMap.transform.localScale.y - increment, zoomOutMin, zoomOutMax);
        newScale.z = Mathf.Clamp(ImageMap.transform.localScale.z - increment, zoomOutMin, zoomOutMax);
        ImageMap.transform.localScale = newScale;
    }
}