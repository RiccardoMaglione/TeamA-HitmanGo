using DG.Tweening;
using HGO.core.data;
using System;
using UnityEngine;

namespace HGO
{
    namespace core
    {
        [RequireComponent(typeof(SpriteRenderer))]
        public class ItemNode : Node
        {
            [System.Serializable]
            public struct NodeStyle
            {
                [Tooltip("Sprite NORMALE: nessun'azione usando questo nodo")]
                public Sprite normal;
                [Tooltip("Sprite FOCUS: il giocatore clicca o passa il mouse sopra questo nodo")]
                public Sprite focus;
                [Tooltip("Sprite USED: Il nodo esaurisce il proprio effetto (pickup oggetto effettuato)")]
                public Sprite used;
                
                [Space(5)]
                public AudioClip sfx_pickup;

                internal Action OnFocus;
                internal Action OnPickup;
            }
            [Space(5)]
            public NodeStyle style;

            NodeSelectionOperation operation;

            /*
            =================================================================================================
                                                      EVENTS
            =================================================================================================
            */

            /// <summary>
            /// Questo Evento viene chiamato quando il giocatore raggiunge questo nodo
            /// </summary>
            static Action OnPickup;

            /*
          =================================================================================================
                                                    EVENTS CALLBACKS
          =================================================================================================
          */

            void PickupItem()
            {
                OnPickup();
            }

            /*
          =================================================================================================
                                                    UNITY CALLBACKS
          =================================================================================================
          */

            protected new void Awake()
            {
                base.Awake();

                if(OnPickup == null)
                {
                    //EVENTS SUBSCRIPTION
                    OnPickup += CreateNodeSelectionRequest;
                    OnPickup += PlayEffectSoundSource;
                }
                
            }
            protected void Update()
            {
                if(operation!=null)
                {
                    //OPERATION EVENT CALLING BACK
                    if(operation.OnSelectionCompleted == null)
                    {
                        operation.OnSelectionCompleted += CreateLaunch;
                        operation.OnSelectionCompleted += operation.UndoSelection;
                    }

                    //INPUT HANDLER
                    if (Input.GetMouseButtonUp(0))
                    {
                        RaycastHit hit;
                        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
                        if (Physics.Raycast(r, out hit))
                        {
                            var item = hit.collider.gameObject.GetComponentInParent<Node>();
                            if (item is Node)
                            {
                                operation.RegisterNode(item);
                                operation.CheckSelectionOperation();
                            }
                        }
                    }
                }

                if(Input.GetKeyDown(KeyCode.Space))
                {
                    OnPickup();
                }
                
                
            }

            /*
          =================================================================================================
                                                    CLASS METHODS
          =================================================================================================
          */

            void CreateNodeSelectionRequest()
            {
                operation = NodeSelectionOperator.CreateNodeSelectionOperator(NodeSelectionOperator.nodeTypeOperation.ALL, Resources.Load<ThrowingData>("DATA/ThrowingSystem/ThrowingData"),gameObject.transform.position, this);
            }

            void PlayEffectSoundSource()
            {

            }

            void CreateLaunch()
            {
                var data = Resources.Load<ThrowingData>("DATA/ThrowingSystem/ThrowingData");
                var item = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Items/Default_ThrowingItem"));
                item.transform.position = gameObject.transform.position + Vector3.up;
                item.transform.DOJump(operation.selectedNode.gameObject.transform.position, data.launch_force, 1, data.throw_duration);
            }
        }
    }
}