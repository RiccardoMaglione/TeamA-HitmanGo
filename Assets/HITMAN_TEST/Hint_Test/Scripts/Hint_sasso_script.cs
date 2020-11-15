using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint_sasso_script : MonoBehaviour
{
    public GameObject Sprite;
    public GameObject Triggers;

    private ThrowItem Script_Sasso;
    public static bool Areadistrutta = false;


    private void Start()
    {
        Areadistrutta = false;
        Script_Sasso = GameObject.FindObjectOfType<ThrowItem>();

    }

    public void Update()
    {
        
        Attesa();
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            //Sprite.SetActive(true);
            //gameObject.SetActive(true);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Sprite.SetActive(true);
            //gameObject.SetActive(true);
            //Triggers.SetActive(true);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") 
        {
            gameObject.SetActive(false);
            
        }
    }

    private void Attesa()
    {
        if( Areadistrutta == true)
        {
            
            Triggers.SetActive(true);
            Sprite.SetActive(true);
        }
      
    }

    

}
