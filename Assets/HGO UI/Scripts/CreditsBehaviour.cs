using UnityEngine;
using UnityEngine.UI;

public class CreditsBehaviour : MonoBehaviour
{
    public Scrollbar scrollbar;
    bool press = false;

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
            press = false;

        if (Input.GetMouseButtonDown(0))
            press = true;
        
        if(!press)
            scrollbar.value -= Time.deltaTime/10;
    }
}
