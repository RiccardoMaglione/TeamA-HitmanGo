using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLevelSelection : MonoBehaviour
{
    void Start()
    {
        GetComponent<CameraLevelSelection>().enabled = false;
        GetComponent<CameraSelectionMobile>().enabled = false;
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            GetComponent<CameraLevelSelection>().enabled = true;
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            GetComponent<CameraSelectionMobile>().enabled = true;
        }
    }
}
