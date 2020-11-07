using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BUTTON_HINT : MonoBehaviour
{
    public void NuovaPartita(string LivelloGioco)
    {
        SceneManager.LoadScene(LivelloGioco);
        Debug.Log("attivohint");       
    }
}
