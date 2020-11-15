using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateTotalQuest : MonoBehaviour
{
    public Text TotQuestCompletedPC;
    public Text TotQuestCompletedMOBILE;
    // Start is called before the first frame update
    void Start()
    {   
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            TotQuestCompletedPC.text = PlayerPrefs.GetInt("TotalQuest").ToString();
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            TotQuestCompletedMOBILE.text = PlayerPrefs.GetInt("TotalQuest").ToString();
        }
    }
}
