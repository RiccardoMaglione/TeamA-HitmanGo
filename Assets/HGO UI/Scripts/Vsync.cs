using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class Vsync : MonoBehaviour
{
    public int Sync;
    public Text OnOffText;
    // Start is called before the first frame update
    void Start()
    {
        Sync = QualitySettings.vSyncCount;

        if (QualitySettings.vSyncCount == 1)
        {
            OnOffText.text = "ON";
        }
        else if (QualitySettings.vSyncCount == 0)
        {
            OnOffText.text = "OFF";
        }
    }

    public void SetVSync()
    {
        if (Sync == 1)
        {
            QualitySettings.vSyncCount = 0;
            Sync = QualitySettings.vSyncCount;
            OnOffText.text = "OFF";
        }
        else if (Sync == 0)
        {
            QualitySettings.vSyncCount = 1;
            Sync = QualitySettings.vSyncCount;
            OnOffText.text = "ON";
        }
    }
}
