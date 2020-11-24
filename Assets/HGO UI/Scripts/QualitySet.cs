using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QualitySet : MonoBehaviour
{
    public int GetQuality;
    public Text TextQuality;

    void Start()
    {
        if (!PlayerPrefs.HasKey("QualitySet"))
        {
            PlayerPrefs.SetInt("QualitySet", 3);
            TextQuality.text = "High";
        }
        else
        {
            GetQuality = PlayerPrefs.GetInt("QualitySet");
            QualitySettings.SetQualityLevel(GetQuality, true);
            if (GetQuality == 1)
            {
                TextQuality.text = "High";
            }
            if (GetQuality == 3)
            {
                TextQuality.text = "Low";
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeQuality()
    {
        if (GetQuality == 1)
        {
            QualitySettings.SetQualityLevel(3, true);
            TextQuality.text = "High";
            PlayerPrefs.SetInt("QualitySet", 3);
            GetQuality = PlayerPrefs.GetInt("QualitySet");
        }
        if (GetQuality == 3)
        {
            QualitySettings.SetQualityLevel(1, true);
            TextQuality.text = "Low";
            PlayerPrefs.SetInt("QualitySet", 1);
            GetQuality = PlayerPrefs.GetInt("QualitySet");
        }
    }
}
