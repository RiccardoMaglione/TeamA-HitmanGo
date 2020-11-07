using UnityEngine;

namespace HGO.core
{
    public class EndNode : Node
    {
        public Quest LevelManager;
        private void Start()
        {
            EnemyCemetery.CountEnemy = 0;
            LevelManager.Completed = true;
        }
    }
}