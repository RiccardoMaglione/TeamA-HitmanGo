using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTitleManager : MonoBehaviour
{
    public Text levelTitle;

    private void OnEnable()
    {
        levelTitle.text = SceneManager.GetActiveScene().name;
    }
}
