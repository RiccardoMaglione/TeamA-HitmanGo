using HGO.core.data;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HGO
{
    namespace core
    {
        public sealed class NodeSelectionOperation
        {
            Vector3 location = Vector3.zero;
            internal Node selectedNode = null;

            internal Action OnSelectionCompleted;

            List<Node> InRangeNodes = new List<Node>();

            public NodeSelectionOperation(ThrowingData tData, Vector3 origin, NodeSelectionOperator.nodeTypeOperation type, Node start_node)
            {
                location = origin;
                selectedNode = null;

                List<Node> rangedNode = new List<Node>();
                LevelManager level = GameObject.FindObjectOfType<LevelManager>();

                //FINDS ALL TRIGGERABLE NODES
                foreach(Node n in /*level.levelNodes*/ GameObject.FindObjectsOfType<Node>().ToList())
                {
                    if(IsInRange(n, tData) && n != start_node)
                    {
                        rangedNode.Add(n);
                    }
                }

                //FOCUS ALL ITERACTABLE NODES
                foreach(Node n in rangedNode)
                {
                    ActivateNodeSelection(n);
                }

                InRangeNodes = rangedNode;

            }

            /// <summary>
            /// Controlla se il nodo e' nel range per la selezione
            /// </summary>
            /// <param name="n"></param>
            /// <param name="tData"></param>
            /// <returns></returns>
            bool IsInRange(Node n, ThrowingData tData)
            {
                if (n == null) Debug.Log("invalid node");
                else if (tData == null) Debug.Log("invali data");

                return (n.gameObject.transform.position.x <= (location.x + 5) * tData.throw_area && n.gameObject.transform.position.x >= (location.x - 5) * tData.throw_area) &&
                       (n.gameObject.transform.position.z <= (location.z + 5) * tData.throw_area && n.gameObject.transform.position.z >= (location.z - 5) * tData.throw_area);
            }
            /// <summary>
            /// Controlla se il giocatore ha selezionato un'input
            /// </summary>
            public void CheckSelectionOperation()
            {
                try
                {
                    if (selectedNode != null && IsValidNode()) OnSelectionCompleted();
                }
                catch
                {
                    Debug.LogWarning("Attention! NodeSelectionOperation.CheckSelectionOperation(): loading selection procedure...");
                }
            }
            /// <summary>
            /// Attiva un nodo
            /// </summary>
            void ActivateNodeSelection(Node n)
            {
                n.gameObject.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
            }
            /// <summary>
            /// Disattiva un nodo
            /// </summary>
            void DeactivateNodeSelection(Node n)
            {
                n.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
                InRangeNodes.Remove(n);
            }
            /// <summary>
            /// Termina la procedura di selezione
            /// </summary>
            public void UndoSelection()
            {

                try
                {
                    foreach (Node n in InRangeNodes)
                    {
                        n.gameObject.GetComponentInChildren<MeshRenderer>().material.color = Color.white;
                    }
                }
                catch
                {
                    Debug.LogWarning("Attention! NodeSelectionOperation.UndoSelection(): can't deselect nodes");
                }
                finally
                {
                    Debug.Log("NodeSelectionOperation(): Release Memory");
                    InRangeNodes.Clear();
                    InRangeNodes = null;
                    selectedNode = null;
                }

            }
            /// <summary>
            /// TODO: Stermina la procedura di selezione
            /// </summary>
            public void Close()
            {
                // do some stuff
            }

            /// <summary>
            /// Registra il nodo selezionato dall'utente
            /// </summary>
            /// <param name="n"></param>
            public void RegisterNode(Node n)
            {
                selectedNode = n;
            }

            bool IsValidNode()
            {
                foreach(Node n in InRangeNodes)
                {
                    if (n == selectedNode) return true;
                }
                return false;
            }
            
        }
    }
}