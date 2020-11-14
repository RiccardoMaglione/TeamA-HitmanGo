using UnityEngine;
using UnityEngine.UI;

public class Vsync : MonoBehaviour
{
    public int Sync;
    public Text OnOffText;
    public Sprite spriteActive;
    public Sprite spriteNotActive;
    public Image image;

    void Start()
    {
        Sync = QualitySettings.vSyncCount;

        if (QualitySettings.vSyncCount == 1)
        {
            OnOffText.text = "ON";
        }
        else if (QualitySettings.vSyncCount == 0)
        {
            OnOffText.text = "OFF";
        }
    }

    public void SetVSync()
    {
        if (Sync == 1)
        {
            image.sprite = spriteNotActive;
            QualitySettings.vSyncCount = 0;
            Sync = QualitySettings.vSyncCount;
            OnOffText.text = "OFF";
        }
        else if (Sync == 0)
        {
            image.sprite = spriteActive;
            QualitySettings.vSyncCount = 1;
            Sync = QualitySettings.vSyncCount;
            OnOffText.text = "ON";
        }
    }
}
