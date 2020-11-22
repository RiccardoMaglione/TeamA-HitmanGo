using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HintManagerLv6 : MonoBehaviour
{
    public void HintActivate()
    {
        SceneManager.LoadScene("Level1-6+hint");
    }
}