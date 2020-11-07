using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using HGO.core;
using HGO;

public class IconLevel : MonoBehaviour
{
    public GameObject[] IconNotComplete;
    public GameObject[] IconComplete;
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
        IconComplete[0].transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 1);
        yield return new WaitForSeconds(0.75f);
        IconNotComplete[0].SetActive(false);
    }
    public IEnumerator IconLevel2()
    {
        IconComplete[1].transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 1);
        yield return new WaitForSeconds(0.75f);
        IconNotComplete[1].SetActive(false);
    }
    public IEnumerator IconLevel3()
    {
        IconComplete[2].transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 1);
        yield return new WaitForSeconds(0.75f);
        IconNotComplete[2].SetActive(false);
    }
    public IEnumerator IconLevel4()
    {
        IconComplete[3].transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 1);
        yield return new WaitForSeconds(0.75f);
        IconNotComplete[3].SetActive(false);
    }
    public IEnumerator IconLevel5()
    {
        IconComplete[4].transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 1);
        yield return new WaitForSeconds(0.75f);
        IconNotComplete[4].SetActive(false);
    }
    public IEnumerator IconLevel6()
    {
        IconComplete[5].transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 1);
        yield return new WaitForSeconds(0.75f);
        IconNotComplete[5].SetActive(false);
    }

}
