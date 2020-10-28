using HGO.core;
using UnityEngine;

namespace HGO
{
    namespace ai
    {
        /// <summary>
        /// Questo Componente permette all'AI di osservare un nodo di fronte al proprio
        /// </summary>
        [RequireComponent(typeof(AI_Controller))]
        public class AI_Vision : MonoBehaviour
        {
            LevelManager lm = null;

            [Header("Settings"), Space(5)]
            public Node currentNode;
            [SerializeField]
            public Node forwardNode;

            #region UnityCallbacks
            protected void Awake()
            {
                if (!lm) lm = FindObjectOfType<LevelManager>();

            }
            private void OnEnable()
            {
                RegisterForwardNode();
            }
            #endregion

            /// <summary>
            /// Registra il nodo che ha di fronte l'intelligenza artificiale
            /// </summary>
            public void RegisterForwardNode()
            {
                var rot = gameObject.transform.rotation;
                Node nod = null;

                if (rot == Quaternion.Euler(0, 0, 0)) //forward
                {
                    nod = Pathfinder.GetNeighbourNode(ref lm, AI_ORIENTATION.up, currentNode);
                    if (nod == null) UnityEngine.Debug.LogError("Attention! AI_Vision.RegisterNode(): can't find a node");
                }
                else if (rot == Quaternion.Euler(0, 90, 0)) // right
                {
                    nod = Pathfinder.GetNeighbourNode(ref lm, AI_ORIENTATION.right, currentNode);
                    if (nod == null) UnityEngine.Debug.LogError("Attention! AI_Vision.RegisterNode(): can't find a node");
                }
                else if (rot == Quaternion.Euler(0, 180, 0)) // back
                {
                    nod = Pathfinder.GetNeighbourNode(ref lm, AI_ORIENTATION.down, currentNode);
                    if (nod == null) UnityEngine.Debug.LogError("Attention! AI_Vision.RegisterNode(): can't find a node");
                }
                else if(rot == Quaternion.Euler(0,270,0)) // left
                {
                    nod = Pathfinder.GetNeighbourNode(ref lm, AI_ORIENTATION.left, currentNode);
                    if (nod == null) UnityEngine.Debug.LogError("Attention! AI_Vision.RegisterNode(): can't find a node");
                }

                forwardNode = nod;
            }

            public void UnregisterForwardNode()
            {
                forwardNode = null;
            }
        }
    }
}