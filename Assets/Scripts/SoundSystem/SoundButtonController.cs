using UnityEngine.UI;
using UnityEngine;

public class SoundButtonController : MonoBehaviour
{
    public Text soundText;
    public Sprite spriteActive;
    public Sprite spriteNotActive;
    public Image image;

    public void SetSound()
    {
        if (PlayerPrefs.GetInt("setSound") == 1)
        {
            PlayerPrefs.SetInt("setSound", 0);
            soundText.text = "SOUND - OFF";
            image.sprite = spriteNotActive;
        }

        else
        {
            PlayerPrefs.SetInt("setSound", 1);
            soundText.text = "SOUND - ON";
            image.sprite = spriteActive;
        }
    }

    void Start()
    {
        if (PlayerPrefs.GetInt("setSound") == 1)
        {
            soundText.text = "SOUND - ON";
            image.sprite = spriteActive;
        }

        else
        {
            soundText.text = "SOUND - OFF";
            image.sprite = spriteNotActive;
        }
    }
}
