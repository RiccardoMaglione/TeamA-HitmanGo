using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fullscreen : MonoBehaviour
{
    static public bool FullS;
    public void SetFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
        FullS = Screen.fullScreen;
    }
}
