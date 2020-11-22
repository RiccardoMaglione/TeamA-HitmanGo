﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using HGO.core;
using HGO;

public class IconLevel : MonoBehaviour
{
    public GameObject[] IconNotCompletePC;
    public GameObject[] IconCompletePC;
    public GameObject[] IconNotCompleteMobile;
    public GameObject[] IconCompleteMobile;

    public static int[] IDQuest = new int[5];

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("QuestLevelComplete" + 0) == 1)
        {
            StartCoroutine(IconLevel1());
        }
        if (PlayerPrefs.GetInt("QuestLevelComplete" + 1) == 1)
        {
            StartCoroutine(IconLevel2());
        }
        if (PlayerPrefs.GetInt("QuestLevelComplete" + 2) == 1)
        {
            StartCoroutine(IconLevel3());
        }
        if (PlayerPrefs.GetInt("QuestLevelComplete" + 3) == 1)
        {
            StartCoroutine(IconLevel4());
        }
        if (PlayerPrefs.GetInt("QuestLevelComplete" + 4) == 1)
        {
            StartCoroutine(IconLevel5());
        }
        
        //StartCoroutine(IconLevel6());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator IconLevel1()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            IconCompletePC[0].transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 1);
            yield return new WaitForSeconds(0.75f);
            IconNotCompletePC[0].SetActive(false);
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            IconCompleteMobile[0].transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 1);
            yield return new WaitForSeconds(0.75f);
            IconNotCompleteMobile[0].SetActive(false);
        }
    }
    public IEnumerator IconLevel2()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            IconCompletePC[1].transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 1);
            yield return new WaitForSeconds(0.75f);
            IconNotCompletePC[1].SetActive(false);
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            IconCompleteMobile[1].transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 1);
            yield return new WaitForSeconds(0.75f);
            IconNotCompleteMobile[1].SetActive(false);
        }
    }
    public IEnumerator IconLevel3()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            IconCompletePC[2].transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 1);
            yield return new WaitForSeconds(0.75f);
            IconNotCompletePC[2].SetActive(false);
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            IconCompleteMobile[2].transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 1);
            yield return new WaitForSeconds(0.75f);
            IconNotCompleteMobile[2].SetActive(false);
        }
    }
    public IEnumerator IconLevel4()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            IconCompletePC[3].transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 1);
            yield return new WaitForSeconds(0.75f);
            IconNotCompletePC[3].SetActive(false);
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            IconCompleteMobile[3].transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 1);
            yield return new WaitForSeconds(0.75f);
            IconNotCompleteMobile[3].SetActive(false);
        }
    }
    public IEnumerator IconLevel5()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            IconCompletePC[4].transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 1);
            yield return new WaitForSeconds(0.75f);
            IconNotCompletePC[4].SetActive(false);
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            IconCompleteMobile[4].transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 1);
            yield return new WaitForSeconds(0.75f);
            IconNotCompleteMobile[4].SetActive(false);
        }
    }
    public IEnumerator IconLevel6()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            IconCompletePC[5].transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 1);
            yield return new WaitForSeconds(0.75f);
            IconNotCompletePC[5].SetActive(false);
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            IconCompleteMobile[5].transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 1);
            yield return new WaitForSeconds(0.75f);
            IconNotCompleteMobile[5].SetActive(false);
        }
    }

}
