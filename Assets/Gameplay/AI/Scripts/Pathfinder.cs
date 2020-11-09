using HGO.core;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
                //goal_distance = (goal.gameObject.transform.position - next.gameObject.transform.position).magnitude;
                goal_distance = Mathf.Abs(goal.gameObject.transform.position.x - next.gameObject.transform.position.x) + Mathf.Abs(goal.gameObject.transform.position.z - next.gameObject.transform.position.z);
                pointedNode = next;

            }
        }



        public class Pathfinder
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
            public static Node GetNeighbourNode(ref LevelManager lm, Vector3 direction, Node currentNode)
            {
                foreach(Node n in lm.levelNodes)
                {
                    if (direction == Vector3.forward)
                    {
                        if (n.nodeData.index == new Vector2(currentNode.nodeData.index.x, currentNode.nodeData.index.y + 1))
                            return n;
                    }
                    else if (direction == Vector3.right)
                    {
                        if (n.nodeData.index == new UnityEngine.Vector2(currentNode.nodeData.index.x + 1, currentNode.nodeData.index.y))
                            return n;
                    }
                    else if(direction == Vector3.back)
                    {
                        if (n.nodeData.index == new UnityEngine.Vector2(currentNode.nodeData.index.x, currentNode.nodeData.index.y - 1))
                            return n;
                    }
                    else if(direction == Vector3.left)
                    {
                        if (n.nodeData.index == new UnityEngine.Vector2(currentNode.nodeData.index.x - 1, currentNode.nodeData.index.y))
                            return n;
                    }
                }

                return null;
            }
            public static Node[] GetNeighbourNodes(ref LevelManager lm, Node current_node)
            {
                List<Node> result = new List<Node>();

                if (current_node.nodeData.connections.up)               result.Add(GetNeighbourNode(ref lm, AI_ORIENTATION.up, current_node));
                if (current_node.nodeData.connections.right)            result.Add(GetNeighbourNode(ref lm, AI_ORIENTATION.right, current_node));
                if (current_node.nodeData.connections.down)             result.Add(GetNeighbourNode(ref lm, AI_ORIENTATION.down, current_node));
                if (current_node.nodeData.connections.left)             result.Add(GetNeighbourNode(ref lm, AI_ORIENTATION.left, current_node));

                return result.ToArray();
            }
            /// <summary>
            /// Restituisce il Nodo piu vicino per raggiungere il nodo obiettivo
            /// </summary>
            /// <param name="current_node"></param>
            /// <param name="goal_node"></param>
            /// <returns></returns>
            public static Node GetNearestNodeOnPattern(Node current_node, Node goal_node, ref LevelManager lm)
            {
                List<Node> openNodes = new List<Node>();
                List<Node> closedNodes = new List<Node>();
                List<Node> bannedNodes = new List<Node>();

                openNodes.Add(current_node);

                while (!openNodes.Contains(goal_node))
                {
                    int index = -1;
                    float value = 1E10f;

                    var neighbours = GetNeighbourNodes(ref lm, openNodes[openNodes.Count - 1]);
                    /* Find nearest Node*/
                    for (int i = 0; i < neighbours.Length; i++)
                    {

                        if (GetDistance(neighbours[i].gameObject.transform.position, openNodes[openNodes.Count - 1].gameObject.transform.position) + GetDistance(neighbours[i].gameObject.transform.position, goal_node.gameObject.transform.position) <= value)
                        {
                            if (!closedNodes.Contains(neighbours[i]))
                            {
                                index = i;
                                value = GetDistance(neighbours[i].gameObject.transform.position, openNodes[openNodes.Count - 1].gameObject.transform.position) + GetDistance(neighbours[i].gameObject.transform.position, goal_node.gameObject.transform.position);
                            }
                        }
                       
                    }

                    if (index == -1) // NODE NOT FOUND
                    {
                        if(openNodes[openNodes.Count - 1] == goal_node) // IF TARGET NODE
                        {
                            break;
                        }
                        else
                        {
                            bannedNodes.Add(openNodes[openNodes.Count - 1]);
                            bannedNodes.Remove(current_node);

                            closedNodes.Clear();
                            openNodes.Clear();

                            openNodes.Add(current_node);
                            
                            foreach(Node n in bannedNodes)
                            {
                                closedNodes.Add(n);
                            }
                        }
                    }
                    else // NODE FOUND
                    {
                        closedNodes.Add(openNodes[openNodes.Count - 1]);
                        openNodes.Add(neighbours[index]);
                    }
                    
                    value = 1E10f;

                }
                  /*Debug*/
                //for(int i = 1; i <= openNodes.Count; i++)
                //{
                //    Debug.LogError($"{i - 1}. {openNodes[i - 1].name}");
                //}

                return openNodes[1];
            }

            static float GetDistance(Vector3 from, Vector3 to)
            {
                return Mathf.Abs(from.x - to.x) + Mathf.Abs(from.z - to.z);
            }

            
        }
    }
}
