using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HintManagerLv5 : MonoBehaviour
{
    public void HintActivate()
    {
        SceneManager.LoadScene("Level1-5+hint");
    }
}
