﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Struct
[System.Serializable]
public struct QuestStruct           //List of quest of game
{
    public bool LevelComplete;
    public bool NoKill;
    public bool AllKill;
}
#endregion

public class Quest : MonoBehaviour
{
    #region Variables
    [Header("Quest Parameters")]

    [Tooltip("ID that indicated a quest for specific level")]
    public int ID;

    [Tooltip("Struct for list of quest present in this level")]
    public QuestStruct QS;

    [Tooltip("Temp - Bool for test for complete a level")]
    public bool Completed = false;

    int[] QuestLevelComplete;
    int[] QuestNoKill;
    int[] QuestAllKill;

    [Header("Total amount of quest")]

    [Tooltip("Total amount of quest of game")]
    public int AmountQuest;
    #endregion

    void Start()
    {
        InitializedSaveQuest();
    }

    void Update()
    {
        ControlQuest();
        ResetQuest();
    }

    #region Method
    public void InitializedSaveQuest()
    {
        #region Init Array
        QuestLevelComplete = new int[AmountQuest];
        QuestNoKill = new int[AmountQuest];
        QuestAllKill = new int[AmountQuest];
        #endregion
        #region Init Save
        #region Quest - Level Complete
        QuestLevelComplete[ID] = PlayerPrefs.GetInt("QuestLevelComplete" + ID);
        if (QuestLevelComplete[ID] == 1)
        {
            QS.LevelComplete = true;
        }
        #endregion
        #region Quest - No Kill
        QuestNoKill[ID] = PlayerPrefs.GetInt("QuestNoKill" + ID);
        if (QuestNoKill[ID] == 1)
        {
            QS.NoKill = true;
        }
        #endregion
        #region Quest - All Kill
        QuestAllKill[ID] = PlayerPrefs.GetInt("QuestAllKill" + ID);
        if (QuestAllKill[ID] == 1)
        {
            QS.AllKill = true;
        }
        #endregion
        #endregion
    }

    public void ControlQuest()
    {
        if (QS.LevelComplete == true && Completed == true)
        {
            QuestLevelComplete[ID] = 1;
            PlayerPrefs.SetInt("QuestLevelComplete" + ID, QuestLevelComplete[ID]);
        }
        if (QS.NoKill == true && Completed == true)
        {
            QuestNoKill[ID] = 1;
            PlayerPrefs.SetInt("QuestNoKill" + ID, QuestNoKill[ID]);
        }
        if (QS.AllKill == true && Completed == true)
        {
            QuestAllKill[ID] = 1;
            PlayerPrefs.SetInt("QuestAllKill" + ID, QuestAllKill[ID]);
        }
    }

    public void ResetQuest()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Reset quest");

            Completed = false;

            QuestLevelComplete[ID] = 0;
            PlayerPrefs.SetInt("QuestLevelComplete" + ID, QuestLevelComplete[ID]);

            QuestNoKill[ID] = 0;
            PlayerPrefs.SetInt("QuestNoKill" + ID, QuestNoKill[ID]);

            QuestAllKill[ID] = 0;
            PlayerPrefs.SetInt("QuestAllKill" + ID, QuestAllKill[ID]);
        }
    }
    #endregion
}
