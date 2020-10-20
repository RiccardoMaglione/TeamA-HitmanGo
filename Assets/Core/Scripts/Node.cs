using HGO.ai;
using System.Collections.Generic;
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
            /// <summary>
            /// Indice della griglia di movimento
            /// Fornisce un sistema di mappatura per ogni griglia come un indice 2D (x, y)
            /// i.e. cella centrale: (0,0), cella davanti a quella centrale (0,1)
            /// </summary>
            public Vector2 index;
            /// <summary>
            /// Direzioni disponibili per il movimento
            /// </summary>
            public SConnections connections;
            internal List<CharacterController> overlappedCharacters;
            internal List<AI_Controller> overlappedEnemies;
            /// <summary>
            /// Restituisce il numero totale di personaggi sopra la cella
            /// </summary>
            internal int overlappedCharactersCount    { get { return overlappedCharacters.Count; } }
            /// <summary>
            /// Restituisce il numero totale di nemici sopra la cella
            /// </summary>
            internal int overlappedEnemiesCount       { get { return overlappedEnemies.Count; } }
        }

        [RequireComponent(typeof(BoxCollider))]
        public class Node : MonoBehaviour
        {
            public NodeData nodeData;

            #region UnityCallbacks
            protected void Awake()
            {
                if(!Init())
                {
                    Debug.LogError("Attention! Node: Can't initalize NODE CLASS properly");
                    Application.Quit();
                }
            }
            protected void OnTriggerEnter(Collider other)
            {
                var character = other.gameObject.GetComponent<CharacterController>();

                if(character is PlayerController)
                {
                    Debug.Log($"character on cell {character}");
                    nodeData.overlappedCharacters.Add(character);
                }
                else if(character is AI_Controller)
                {
                    Debug.Log($"character on cell {character}");
                    nodeData.overlappedCharacters.Add(character);
                    nodeData.overlappedEnemies.Add(other.gameObject.GetComponent<AI_Controller>());
                }
            }

            protected void OnTriggerExit(Collider other)
            {
                var character = other.gameObject.GetComponent<CharacterController>();

                if(character is PlayerController)
                {
                    nodeData.overlappedCharacters.Remove(character);
                }
                else if(character is AI_Controller)
                {
                    nodeData.overlappedCharacters.Remove(character);
                    nodeData.overlappedEnemies.Remove(other.gameObject.GetComponent<AI_Controller>());
                }
            }
            #endregion

            bool Init()
            {
                nodeData.overlappedCharacters = new List<CharacterController>();
                nodeData.overlappedEnemies = new List<AI_Controller>();

                return true;
            }
        }
    }
}

