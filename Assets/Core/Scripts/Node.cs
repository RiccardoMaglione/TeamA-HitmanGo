using System;
using System.Collections.Generic;
using UnityEngine;


namespace HGO
{

    namespace core
    {
        // Represent the 4 possible direction;
        //
        [System.Serializable]
        public struct SConnections
        {
            public bool up;
            public bool right;
            public bool down;
            public bool left;
        }

        // Represent the data receiving of each node
        //
        [System.Serializable]
        public struct NodeData
        {
            public Vector2 index;                          
            public SConnections connections;                
            internal PlayerController registredActor;                
            public uint overlappedCharactersCount { get { return (uint)overlappedCharacters.Count; } }
            internal List<CharacterController> overlappedCharacters;
        }

        [RequireComponent(typeof(BoxCollider))]
        public class Node : MonoBehaviour
        {
            BoxCollider bc;
            public NodeData data;
            List<Vector3> pPositions;                   // posizioni disponibili sulla cella
            Action OnSlotOverload;                      // definisce il comportamento quando ci sono piu personaggi sul nodo

            private void Awake()
            {
                if(!Init())
                {
                    Application.Quit();
                }
            }

            protected void OnTriggerEnter(Collider other)
            {
                var cc = other.gameObject.GetComponent<CharacterController>();

                if(cc != null)
                {
                    data.overlappedCharacters.Add(cc);
                }

                if(data.overlappedCharactersCount > 1)
                {

                }
            }
            protected void OnTriggerExit(Collider other)
            {
                var cc = other.gameObject.GetComponent<CharacterController>();

                if (cc != null)
                {
                    data.overlappedCharacters.Remove(cc);
                }

            }

            bool Init()
            {
                bc = gameObject.GetComponent<BoxCollider>();
                if(!bc.isTrigger)
                {
                    Debug.LogError($"Attention! Node->Init(): {gameObject.name}-> il trigger del box collider deve essere TRUE per poter funzionare\n ");
                    return false;
                }

                return true;
            }

            /// <summary>
            /// TODO: Riposiziona i personaggi sopra che si trovano sopra la cella
            /// </summary>
            void DeployCharacters()
            {
                
            }

            /// <summary>
            /// TODO: Restituisce una lista di vettori che rappresentano la posizioni disponibili su questo nodo
            /// i.e. 4 Personaggi = 4 posizioni
            /// </summary>
            List<Vector3> FillPositionsList()
            {
                var list = new List<Vector3>();

                for(int i = 0; i<data.overlappedCharactersCount; i++)
                {
                    
                }

                return list;
            }
        }
    }
}

