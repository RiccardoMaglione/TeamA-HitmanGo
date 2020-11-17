using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Stamp : MonoBehaviour
{
    void Start()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOScale(new Vector3(1, 1, 1), 20));
        mySequence.Append(transform.DOShakePosition(10, 30));
    }
}
