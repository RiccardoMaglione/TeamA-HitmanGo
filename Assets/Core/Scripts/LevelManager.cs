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

            #region UnityCallback
            private void Awake()
            {
                levelNodes = FindObjectsOfType<Node>().ToList();
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
