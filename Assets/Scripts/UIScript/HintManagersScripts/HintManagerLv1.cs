using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HintManagerLv1 : MonoBehaviour
{
    public void HintActivate()
    {
        SceneManager.LoadScene("Level1-1+hint");
    }
}
