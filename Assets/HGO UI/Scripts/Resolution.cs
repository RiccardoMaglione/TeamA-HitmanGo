using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resolution : MonoBehaviour
{
    int[] WidthRes = new int[10];
    int[] HeigthRes = new int[10];
    public int ID;

    public Text ResText;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);

        ResText.text = Screen.currentResolution.width + "x" + Screen.currentResolution.height + ", 60Hz";
        ID = 9;

        WidthRes[0] = 640;
        WidthRes[1] = 800;
        WidthRes[2] = 800;
        WidthRes[3] = 1024;
        WidthRes[4] = 1024;
        WidthRes[5] = 1280;
        WidthRes[6] = 1280;
        WidthRes[7] = 1360;
        WidthRes[8] = 1366;
        WidthRes[9] = Screen.currentResolution.width;


        HeigthRes[0] = 480;
        HeigthRes[1] = 480;
        HeigthRes[2] = 600;
        HeigthRes[3] = 600;
        HeigthRes[4] = 768;
        HeigthRes[5] = 720;
        HeigthRes[6] = 768;
        HeigthRes[7] = 768;
        HeigthRes[8] = 768;
        HeigthRes[9] = Screen.currentResolution.height;

        for (int i = 0; i < 10; i++)
        {
            if(WidthRes[i] == Screen.currentResolution.width)
            {
                if(HeigthRes[i] == Screen.currentResolution.height)
                {
                    ID = i;
                    ResText.text = WidthRes[i].ToString() + "x" + HeigthRes[i].ToString() + ", 60Hz";
                }
            }
            
        }
    }

    public void SetResolutionPlus()
    {
        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Selection Sound");
        
        ID += 1;
        if (ID > 9)
            ID = 0;
        Screen.SetResolution(WidthRes[ID], HeigthRes[ID], Fullscreen.FullS, 60);
        ResText.text = WidthRes[ID].ToString()+"x"+HeigthRes[ID].ToString()+", 60Hz";
    }
    public void SetResolutionMinum()
    {
        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Selection Sound");
        
        ID -= 1;
        if (ID < 0)
            ID = 9;
        Screen.SetResolution(WidthRes[ID], HeigthRes[ID], Fullscreen.FullS, 60);
        ResText.text = WidthRes[ID].ToString() + "x" + HeigthRes[ID].ToString() + ", 60Hz";
    }
}

//Lista resolution

//640x480, 60hz
//800x480, 60hz
//800x600, 60hz
//1024x600, 60hz
//1024x768, 60hz
//1280x720, 60hz
//1280x768, 60hz
//1360x768, 60hz
//1366x768,60hz













