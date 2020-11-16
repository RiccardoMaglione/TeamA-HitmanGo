using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateCamereDevice : MonoBehaviour
{
    static public bool PCVersion = false;
    static public bool MobileVersion = false;

    public Text PCorMobile;

    // Start is called before the first frame update
    void Start()
    {
        PCVersion = false;
        MobileVersion = false;
        if(Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            PCVersion = true;
            PCorMobile.text = "PC Version";
        }
        if(Application.platform == RuntimePlatform.Android)
        {
            MobileVersion = true;
            PCorMobile.text = "Mobile Version";
        }
    }

}
