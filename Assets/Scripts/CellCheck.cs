using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellCheck : MonoBehaviour
{
    #region Variables
    [Header("Available direction of cell")]
    public bool Nord = false;
    public bool Sud = false;
    public bool Est = false;
    public bool Ovest = false;

    static public bool UnlockNord = false;
    static public bool UnlockSud = false;
    static public bool UnlockEst = false;
    static public bool UnlockOvest = false;
    #endregion
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Nord == true)
            {
                UnlockNord = true;
            }
            if (Sud == true)
            {
                UnlockSud = true;
            }
            if (Est == true)
            {
                UnlockEst = true;
            }
            if (Ovest == true)
            {
                UnlockOvest = true;
            }
        }
    }
}