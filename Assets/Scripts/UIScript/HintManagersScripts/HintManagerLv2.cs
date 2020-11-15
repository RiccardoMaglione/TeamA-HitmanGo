using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HintManagerLv2 : MonoBehaviour
{
    public void HintActivate()
    {
        SceneManager.LoadScene("Level1-2+hint");
    }
}
