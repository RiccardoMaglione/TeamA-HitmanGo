using HGO.core;
using System.Collections.Generic;

namespace HGO
{
    namespace ai
    {
        public enum AI_ORIENTATION { up, right, down, left }

        /// <summary>
        /// La struttura di dati di un nodo per il pathfinding
        /// </summary>
        struct pathfinding_node
        {
            float node_distance;
            float goal_distance;
            internal Node pointedNode;
            public float value
            {
                get
                {
                    return node_distance + goal_distance;
                }
            }

            public pathfinding_node(Node current, Node next, Node goal)
            {
                node_distance = (next.gameObject.transform.position - current.gameObject.transform.position).magnitude;
                goal_distance = (goal.gameObject.transform.position - next.gameObject.transform.position).magnitude;
                pointedNode = next;

            }
        }

        public static class Pathfinder
        {

            /// <summary>
            /// Returns the next node based on the current node and direction
            /// If failed returns NULL
            /// </summary>
            /// <param name="lm">Gestore del livello corrente</param>
            /// <param name="direction">direzione</param>
            /// <param name="currentNode">nodo nel quale ci si trova</param>
            /// <returns></returns>
            public static Node GetNeighbourNode(ref LevelManager lm, AI_ORIENTATION direction, Node currentNode)
            {
                //ricerca il nodo nella direzione passata
                foreach(Node n in lm.levelNodes)
                {

                    switch (direction)
                    {
                        case AI_ORIENTATION.up:

                            if (n.nodeData.index == new UnityEngine.Vector2(currentNode.nodeData.index.x, currentNode.nodeData.index.y + 1))
                                return n;
                            break;
                        case AI_ORIENTATION.right:

                            if (n.nodeData.index == new UnityEngine.Vector2(currentNode.nodeData.index.x + 1, currentNode.nodeData.index.y))
                                return n;
                            break;
                        case AI_ORIENTATION.down:

                            if (n.nodeData.index == new UnityEngine.Vector2(currentNode.nodeData.index.x, currentNode.nodeData.index.y - 1))
                                return n;
                            break;
                        case AI_ORIENTATION.left:

                            if (n.nodeData.index == new UnityEngine.Vector2(currentNode.nodeData.index.x - 1, currentNode.nodeData.index.y))
                                return n;
                            break;
                    }

                }

                return null;
            }
            /// <summary>
            /// Restituisce il Nodo piu vicino per raggiungere il nodo obiettivo
            /// </summary>
            /// <param name="current_node"></param>
            /// <param name="goal_node"></param>
            /// <returns></returns>
            public static Node GetNearestNodeOnPattern(Node current_node, Node goal_node, ref LevelManager lm)
            {
                List<pathfinding_node> nodes = new List<pathfinding_node>();

                /* Verifica delle possibili connessioni e creazioni dei dati per l'intelligenza artificiale*/
                if(current_node.nodeData.connections.up)         nodes.Add(new pathfinding_node(current_node, GetNeighbourNode(ref lm, AI_ORIENTATION.up, current_node), goal_node));
                if(current_node.nodeData.connections.right)      nodes.Add(new pathfinding_node(current_node, GetNeighbourNode(ref lm, AI_ORIENTATION.right, current_node), goal_node));
                if(current_node.nodeData.connections.down)       nodes.Add(new pathfinding_node(current_node, GetNeighbourNode(ref lm, AI_ORIENTATION.down, current_node), goal_node));
                if(current_node.nodeData.connections.left)       nodes.Add(new pathfinding_node(current_node, GetNeighbourNode(ref lm, AI_ORIENTATION.left, current_node), goal_node));

                if (nodes.Count < 1) return null;       // Breakpoint - means none connection available

                float path_lenght = 0;
                int index = -1;

                /* Controllo il percorso piu breve */
                for(int i = 0; i < nodes.Count; i++)
                {
                    // controllo se sono esattamente a 1 nodo di distanza
                    foreach(pathfinding_node n in nodes)
                    {
                        if (n.pointedNode == goal_node) return n.pointedNode;
                    }

                    if (i == 0)
                    {
                        path_lenght = nodes[i].value;
                        index = i;
                    }
                    else
                    {
                        if(nodes[i].value < path_lenght)
                        {
                            index = i ;
                            path_lenght = nodes[i].value;
                        }
                    }
                }

                return nodes[index].pointedNode;
            }

        }
    }
}
