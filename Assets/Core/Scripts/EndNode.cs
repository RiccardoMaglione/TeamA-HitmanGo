using UnityEngine;
using UnityEngine.SceneManagement;

namespace HGO.core
{
    public class EndNode : Node
    {
        public Quest LevelManager;
        private void Start()
        {
            EnemyCemetery.CountEnemy = 0;
            
        }
        private void OnTriggerEnter(Collider other)
        {
            var character = other.gameObject.GetComponent<HGO.core.CharacterController>();

            if (character is PlayerController)
            {
                Scene scene = SceneManager.GetActiveScene();
                if (scene.name == "GO 1-1"  ||scene.name == "Level1-1+hint")
                {
                    PlayerPrefs.SetInt("UnblockTwo", 1);
                }
                if (scene.name == "GO 1-2"  ||scene.name == "Level1-2+hint")
                {
                    PlayerPrefs.SetInt("UnblockThree", 1);
                }
                if (scene.name == "GO 1-3"  ||scene.name == "Level1-3+hint")
                {
                    PlayerPrefs.SetInt("UnblockFour", 1);
                }
                if (scene.name == "GO 1-4"  ||scene.name == "Level1-4+hint")
                {
                    PlayerPrefs.SetInt("UnblockFive", 1);
                }
                if (scene.name == "GO 1-5" || scene.name == "Level1-5+hint")
                {
                    PlayerPrefs.SetInt("UnblockSix", 1);
                }
                LevelManager.Completed = true;
                print("Completa è " + LevelManager.Completed);
            }
        }
    }
}