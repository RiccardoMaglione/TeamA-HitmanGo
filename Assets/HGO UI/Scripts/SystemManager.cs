using UnityEngine;

public class SystemManager : MonoBehaviour
{
    public GameObject mobileUi, pcUi;

    void Awake()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer)
            pcUi.SetActive(true);

        else
            mobileUi.SetActive(true);
    }
}
