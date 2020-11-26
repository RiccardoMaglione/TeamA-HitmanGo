using UnityEngine.UI;
using UnityEngine;

public class SoundButtonController : MonoBehaviour
{
    public Text soundText;
    public Sprite spriteActive;
    public Sprite spriteNotActive;
    public Image image;

    public Text soundTextMobile;
    public Image imageMobile;

    public void SetSound()
    {
        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Selection Sound");
        
        if (PlayerPrefs.GetInt("setSound") == 1)
        {
            PlayerPrefs.SetInt("setSound", 0);
            
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                soundText.text = "SOUND - OFF";
                image.sprite = spriteNotActive;
            }
            
            if(Application.platform == RuntimePlatform.Android)
            {
                soundTextMobile.text = "SOUND - OFF";
                imageMobile.sprite = spriteNotActive;
            }
        }

        else
        {
            PlayerPrefs.SetInt("setSound", 1);
            
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                soundText.text = "SOUND - ON";
                image.sprite = spriteActive;
            }

            if (Application.platform == RuntimePlatform.Android)
            {
                soundTextMobile.text = "SOUND - ON";
                imageMobile.sprite = spriteActive;
            }
        }
    }

    void Start()
    {

        if (PlayerPrefs.GetInt("setSound") == 1)
        {
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                soundText.text = "SOUND - ON";
                image.sprite = spriteActive;
            }

            if (Application.platform == RuntimePlatform.Android)
            {
                soundTextMobile.text = "SOUND - ON";
                imageMobile.sprite = spriteActive;
            }
        }

        else
        {
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                soundText.text = "SOUND - OFF";
                image.sprite = spriteNotActive;
            }

            if (Application.platform == RuntimePlatform.Android)
            {
                soundTextMobile.text = "SOUND - OFF";
                imageMobile.sprite = spriteNotActive;
            }
        }
    }
}
