using UnityEngine;
using UnityEngine.UI;

public class Fullscreen : MonoBehaviour
{
    static public bool FullS;
    public Sprite spriteActive;
    public Sprite spriteNotActive;
    public Image image;

    public void SetFullscreen()
    {
        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Selection Sound");

        if (Screen.fullScreen == true)
            image.sprite = spriteActive;

        if (Screen.fullScreen == false)
            image.sprite = spriteNotActive;

        Screen.fullScreen = !Screen.fullScreen;
        FullS = Screen.fullScreen;
    }
}
