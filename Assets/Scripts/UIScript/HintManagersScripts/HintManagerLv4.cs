using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HintManagerLv4 : MonoBehaviour
{
    public void HintActivate()
    {
        SceneManager.LoadScene("Level1-4+hint");
    }
}
