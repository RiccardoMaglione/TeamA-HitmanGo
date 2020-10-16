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

            private void OnEnable()
            {
                levelNodes = FindObjectsOfType<Node>().ToList();
            }

        }
    }
}
