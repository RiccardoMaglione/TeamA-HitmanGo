using HGO.core;

namespace HGO
{
    namespace ai
    {
        /// <summary>
        /// 
        /// </summary>
        public static class Pathfinder
        {
            public enum orientation { forward, right, down, left}

            /// <summary>
            /// Returns the next node based on the current node and direction
            /// If failed returns NULL
            /// </summary>
            /// <param name="lm">Gestore del livello corrente</param>
            /// <param name="direction">direzione</param>
            /// <param name="currentNode">nodo nel quale ci si trova</param>
            /// <returns></returns>
            public static Node GetNeighbourNode(ref LevelManager lm, orientation direction, Node currentNode)
            {
                //ricerca il nodo nella direzione passata
                foreach(Node n in lm.levelNodes)
                {
                    UnityEngine.Debug.Log($"node index: {n.index}");

                    switch (direction)
                    {
                        case orientation.forward:

                            if (n.index == new UnityEngine.Vector2(currentNode.index.x, currentNode.index.y + 1))
                                return n;
                            break;
                        case orientation.right:

                            if (n.index == new UnityEngine.Vector2(currentNode.index.x + 1, currentNode.index.y))
                                return n;
                            break;
                        case orientation.down:

                            if (n.index == new UnityEngine.Vector2(currentNode.index.x, currentNode.index.y - 1))
                                return n;
                            break;
                        case orientation.left:

                            if (n.index == new UnityEngine.Vector2(currentNode.index.x - 1, currentNode.index.y))
                                return n;
                            break;
                    }

                }

                return null;
            }

        }
    }
}
