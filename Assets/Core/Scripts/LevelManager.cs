using HGO.ai;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HGO
{
    namespace core
    {
        public class LevelManager : MonoBehaviour
        {
            internal List<Node> levelNodes = new List<Node>();
            internal List<AI_Controller> levelEnemies = new List<AI_Controller>();

            #region UnityCallback
            private void Awake()
            {
                levelNodes = FindObjectsOfType<Node>().ToList();
                levelEnemies = FindObjectsOfType<AI_Controller>().ToList();
                #region breakpoint

                if (levelNodes.Count < 1)
                {
                    Debug.LogError("Attention! LevelManager.Awake(): can't initialize node list");
                }


                #endregion
            }
            #endregion

        }
    }
}
