using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HitmanGo
{
    namespace NodeGo
    {
        #region Struct
        [System.Serializable]
        public struct SConnections
        {
            public bool Nord;
            public bool Sud;
            public bool Est;
            public bool Ovest;
        }
        
        [System.Serializable]
        public struct NodeData
        {
            public Vector2 index;
            [Header("Available direction of cell")]
            public SConnections sconnections;
        }
        #endregion

        public class NodeCell : MonoBehaviour
        {
            public NodeData nodeData;
        }
    }
}