using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThreeDots : MonoBehaviour
{
    public Text DotIen;
    public float WaitTime = 0.25f;

    private void Start()
    {
        StartCoroutine(Dots());
    }

    public IEnumerator Dots()
    {
        while (true)
        {
            yield return new WaitForSeconds(WaitTime);
            DotIen.text = "";
            yield return new WaitForSeconds(WaitTime);
            DotIen.text = ".";
            yield return new WaitForSeconds(WaitTime);
            DotIen.text = "..";
            yield return new WaitForSeconds(WaitTime);
            DotIen.text = "...";
        }
    }
}
