using UnityEngine;
using UnityEngine.UI;

public class MusicButtonController : MonoBehaviour
{
    public Text musicText;
    public Sprite spriteActive;
    public Sprite spriteNotActive;
    public Image image;

    public void SetMusic()
    {
        if (PlayerPrefs.GetInt("setMusic") == 1)
        {
            PlayerPrefs.SetInt("setMusic", 0);
            musicText.text = "MUSIC - OFF";
            image.sprite=spriteNotActive;
            AudioManager.instance.Stop("Soundtrack");
        }

        else
        {
            PlayerPrefs.SetInt("setMusic", 1);
            musicText.text = "MUSIC - ON";
            image.sprite = spriteActive;
            AudioManager.instance.Play("Soundtrack");
        }
            
    }

    void Start()
    {
        if (PlayerPrefs.GetInt("setMusic") == 1)
        {
            musicText.text = "MUSIC - ON";
            image.sprite = spriteActive;
        }

        else
        {
            musicText.text = "MUSIC - OFF";
            image.sprite = spriteNotActive;
        }           
    }
}
