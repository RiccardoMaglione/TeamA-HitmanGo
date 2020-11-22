using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Zoom : MonoBehaviour
{
    public Canvas canvas; // The canvas
    public float zoomSpeed = 0.1f;        // The rate of change of the canvas scale factor
    private Vector3 spawnPos;
    private Quaternion spawnRot;
    public Image image;
    float AsseX;
    float AsseY;
    float AsseZ;

    private void Start()
    {
        AsseX = image.transform.position.x;
        AsseY = image.transform.position.y;
        AsseZ = image.transform.position.z;
    }

    void Update()
    {
        if (canvas.scaleFactor == 1)
        {
            image.transform.position = new Vector3(AsseX, AsseY, AsseZ);
        }
        // If there are two touches on the device...
        if (Input.touchCount == 2)
        {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // ... change the canvas size based on the change in distance between the touches.
            canvas.scaleFactor -= deltaMagnitudeDiff * zoomSpeed;

            // Make sure the canvas size never drops below 0.1
            canvas.scaleFactor = Mathf.Max(canvas.scaleFactor, 1f);
            canvas.scaleFactor = Mathf.Min(canvas.scaleFactor, 3f);

        }
        //print(canvas.scaleFactor);
    }
}
