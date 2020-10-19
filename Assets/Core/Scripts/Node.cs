using UnityEngine;


namespace HGO
{
    namespace core
    {
        [System.Serializable]
        public struct SConnections
        {
            public bool up;
            public bool right;
            public bool down;
            public bool left;
        }

        [System.Serializable]
        public struct NodeData
        {
            public Vector2 index;
            [Header("Available direction of cell")]
            public SConnections connections;
        }

        public class Node : MonoBehaviour
        {
            public NodeData nodeData;
        }
    }
}

