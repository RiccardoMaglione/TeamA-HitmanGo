using UnityEngine;

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
                LevelManager.Completed = true;
                print("Completa è " + LevelManager.Completed);
            }
        }
    }
}