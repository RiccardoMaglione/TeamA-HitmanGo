using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLevelSelection : MonoBehaviour
{
    public GameObject ScreenLevelSelectionPc;
    public GameObject ScreenLevelSelectionMobile;
    void Start()
    {
        ScreenLevelSelectionPc.SetActive(false);
        ScreenLevelSelectionMobile.SetActive(false);
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            ScreenLevelSelectionPc.SetActive(true);
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            ScreenLevelSelectionMobile.SetActive(true);
        }
    }
}
