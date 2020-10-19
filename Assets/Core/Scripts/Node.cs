using UnityEngine;


namespace HGO
{
    namespace core
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

        public class Node : MonoBehaviour
        {
            public NodeData nodeData;
        }
    }
}

