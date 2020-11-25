using UnityEngine;
using UnityEngine.UI;

public class MusicButtonController : MonoBehaviour
{
    public Text musicText;
    public Sprite spriteActive;
    public Sprite spriteNotActive;
    public Image image;

    public Text musicTextMobile;
    public Image imageMobile;


    public void SetMusic()
    {
        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Selection Sound");

        if (PlayerPrefs.GetInt("setMusic") == 1)
        {
            PlayerPrefs.SetInt("setMusic", 0);
            
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                musicText.text = "MUSIC - OFF";
                image.sprite = spriteNotActive;
            }

            else
            {
                musicTextMobile.text = "MUSIC - OFF";
                imageMobile.sprite = spriteNotActive;
            }
            
            AudioManager.instance.Stop("Soundtrack");
        }

        else
        {
            PlayerPrefs.SetInt("setMusic", 1);
            
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                musicText.text = "MUSIC - ON";
                image.sprite = spriteActive;
            }

            else
            {
                musicTextMobile.text = "MUSIC - ON";
                imageMobile.sprite = spriteActive;
            }
            
            AudioManager.instance.Play("Soundtrack");
        }         
    }

    void Start()
    {
        if (PlayerPrefs.GetInt("setMusic") == 1)
        {
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                musicText.text = "MUSIC - ON";
                image.sprite = spriteActive;
            }
            
            else
            {
                musicTextMobile.text = "MUSIC - ON";
                imageMobile.sprite = spriteActive;
            }
        }

        else
        {
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                musicText.text = "MUSIC - OFF";
                image.sprite = spriteNotActive;
            }

            else
            {
                musicTextMobile.text = "MUSIC - OFF";
                imageMobile.sprite = spriteNotActive;
            }
        }           
    }
}
