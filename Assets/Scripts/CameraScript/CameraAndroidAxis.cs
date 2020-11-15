using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAndroidAxis : MonoBehaviour
{
    /*app, finger touch (Touc) screen, the script is mounted on the camera, rotate the camera to view the object, and limit the angle and zoom in, the script is mounted on the camera
         */

    public GameObject target;//target moving object

    private Touch oldTouch1; // Last touch point 1 (finger 1)  
    private Touch oldTouch2; // Last touch point 2 (finger 2)  
    private float eulerAngles_x;
    private float eulerAngles_y;
    // Horizontal scroll related
    public float xSpeed = 5;    // main camera horizontal rotation speed
    //Vertical scrolling related  
    public int yMaxLimit = 90; // maximum y(unit is the angle)
    public int yMinLimit = -90;//minimum y (unit is angle)
    public float ySpeed = 10;  // main camera longitudinal rotation speed
    public int xMaxLimit = 90; // maximum y(unit is the angle)
    public int xMinLimit = -90;//minimum y (unit is angle)

    public Vector3 InitPos;
    public Quaternion InitRot;
    public float DelayTime = 20;
    public bool CanLerp;

    IEnumerator IEnumMoveCam()
    {
        float timeSinceStarted = 0f;
        while (true)
        {
            timeSinceStarted += Time.deltaTime / DelayTime;
            if (CanLerp == true)
            {
                transform.position = Vector3.Lerp(transform.position, InitPos, timeSinceStarted);
            }
            else
            {
                yield return new WaitForSeconds(1);
                yield break;
            }

            // If the object has arrived, stop the coroutine
            if (transform.position == InitPos)
            {
                yield return new WaitForSeconds(1);
                yield break;
            }

            // Otherwise, continue next frame
            yield return null;
        }
    }
    IEnumerator IEnumRotCam()
    {
        float timeSinceStarted = 0f;
        while (true)
        {
            timeSinceStarted += Time.deltaTime / DelayTime;
            if (CanLerp == true)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, InitRot, timeSinceStarted);
            }
            else
            {
                yield return new WaitForSeconds(1);
                yield break;
            }

            // If the object has arrived, stop the coroutine
            if (transform.rotation == InitRot)
            {
                yield return new WaitForSeconds(1);
                yield break;
            }

            // Otherwise, continue next frame
            yield return null;
        }
    }

    void Start()
    {
        InitPos = transform.position;
        InitRot = transform.rotation;
        Vector3 eulerAngles = this.transform.eulerAngles;//The Euler angle of the current object  
        this.eulerAngles_x = eulerAngles.y;
        this.eulerAngles_y = eulerAngles.x;
    }

    void Update()
    {
        //No touch  
        if (Input.touchCount <= 0)
        {
            CanLerp = true;

        //    Vector3 eulerAngles = Vector3.zero;//The Euler angle of the current object
        //    //Vector3 eulerAngles = this.transform.eulerAngles;//The Euler angle of the current object  
        //    this.eulerAngles_x = eulerAngles.y;
        //    this.eulerAngles_y = eulerAngles.x;

            StartCoroutine(IEnumMoveCam());
            StartCoroutine(IEnumRotCam());
            return;
        }
        // single touch, horizontal up and down rotation
        if (1 == Input.touchCount)
        {
            CanLerp = false;
            Touch touch = Input.GetTouch(0);
            Vector2 deltaPos = touch.deltaPosition;

            //No dead angle rotation
            //transform.RotateAround(target.transform.position, Vector3.up, deltaPos.x);
            //transform.RotateAround(target.transform.position, -1 * transform.right, deltaPos.y);

            float sum = Vector3.Distance(this.transform.position, target.transform.position);

            if (this.target != null)
            {
                this.eulerAngles_x += ((deltaPos.x * this.xSpeed) * sum) * 0.005f;
                this.eulerAngles_y -= (deltaPos.y * this.ySpeed) * 0.005f;
                this.eulerAngles_y = ClampAngle(this.eulerAngles_y, (float)this.yMinLimit, (float)this.yMaxLimit);
                this.eulerAngles_x = ClampAngle(this.eulerAngles_x, (float)this.xMinLimit, (float)this.xMaxLimit);
                Quaternion quaternion = Quaternion.Euler(this.eulerAngles_y, this.eulerAngles_x, (float)0);
                Vector3 vector = ((Vector3)(quaternion * new Vector3((float)0, (float)0, -sum))) + this.target.transform.position;
                // Change the rotation angle and position of the main camera
                this.transform.rotation = quaternion;
                this.transform.position = vector;
            }

        }

        //Multiple touch, zoom in and out  
        Touch newTouch1 = Input.GetTouch(0);
        Touch newTouch2 = Input.GetTouch(1);

        //The second point is just touching the screen, only recording, no processing  
        if (newTouch2.phase == TouchPhase.Began)
        {
            oldTouch2 = newTouch2;
            oldTouch1 = newTouch1;
            return;
        }

        // Calculate the old two - point distance and the new distance between the two points, become larger to enlarge the model, become smaller to scale the model
        float oldDistance = Vector2.Distance(oldTouch1.position, oldTouch2.position);
        float newDistance = Vector2.Distance(newTouch1.position, newTouch2.position);


        // The difference between the two distances, positive for the zoom gesture, negative for the zoom gesture
        float offset = newDistance - oldDistance;
        // DebugUtil.log("distance between objects:" + Vector3.Distance(this.transform.position, target.transform.position));
        if (offset > 0 && Vector3.Distance(this.transform.position, target.transform.position) > 4)
        {

            transform.Translate(Vector3.forward * 0.1f);
        }
        if (offset < 0 && Vector3.Distance(this.transform.position, target.transform.position) < 10)
        {
            transform.Translate(Vector3.forward * -0.1f);
        }

        //Remember the latest touch points, next time  
        oldTouch1 = newTouch1;
        oldTouch2 = newTouch2;
    }

    // Limit the angle to a given range

    public float ClampAngle(float angle, float min, float max)
    {
        while (angle < -360)
        {
            angle += 360;
        }

        while (angle > 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);

    }
}