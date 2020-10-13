using UnityEngine;


namespace HGO
{
    namespace core
    {
        public class Node : MonoBehaviour
        {
            [System.Serializable]
            public struct SConnections
            {
                public bool up;
                public bool down;
                public bool left;
                public bool right;
            }

            public Vector2 index;
            public SConnections connections;


        }
    }
}

