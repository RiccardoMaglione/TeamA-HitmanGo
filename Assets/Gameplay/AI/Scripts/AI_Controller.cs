using DG.Tweening;
using HGO.core;
using System;
using System.Collections;
using UnityEngine;

namespace HGO
{
    namespace ai
    {

        public class AI_Controller : core.CharacterController
        {
            [Header("Settings"), Space(5)]
            public float MovementDuration = 0.5f;
            public float RotationMovement = 0.5f;
            public Node gn; // da cancellare
            public Node currentNode; // da cancellare
            LevelManager lm;
            AI_Vision eyes;

            #region UnityCallbacks
            protected void Awake()
            {
                if(!Init())
                {
                    Debug.LogError("Attention! AI_CONTROLLER: initzialization FAILED!\n");
                    Application.Quit();
                }

                #region events subscription
                //do some stuff
                #endregion 
            }

            private void OnEnable()
            {
                try
                {
                    eyes.RegisterForwardNode();
                }
                catch
                {
                    Debug.LogWarning("Attention! AI_CONTROLLER: Can't find none node in front of me!\n");
                }
            }

            public void Update()
            {
                if(Input.GetKeyDown(KeyCode.Space)) //CANCELLARE - SOLO TESTING
                {
                    /* SEQUENZA D'ATTACCO */
                    //eyes.RegisterForwardNode();
                    //gameObject.transform.DOMove(eyes.forwardNode.gameObject.transform.position + new Vector3(0,1,0), MovementDuration);
                    //eyes.currentNode = eyes.forwardNode;

                    /* AI MOVEMENT */
                    AI_MOVE();

                }
            }
            protected void OnDestroy()
            {
                eyes = null;
            }
            #endregion

            #region Events
            static Action OnPlayerDetected;
            #endregion

            #region Callbacks
            public void CheckObservedNode()
            {
                if (eyes)
                {
                    if (eyes.forwardNode) OnPlayerDetected(); //aggiungere collider al nodo per verificare se il giocatore ci si trovi sopra
                }
            }
            #endregion

            bool Init()
            {
                if (!lm) lm = FindObjectOfType<LevelManager>();
                if (lm == null) return false;
                if (currentNode == null) return false;

                if (!eyes) eyes = gameObject.GetComponent<AI_Vision>();

                return true;
            }

            /// <summary>
            /// Muove il personaggio verso il punto che ha originato il rumore
            /// </summary>
            public void AI_MOVE()
            {
                if(gn)
                {
                    var Node2Move = Pathfinder.GetNearestNodeOnPattern(currentNode, gn, ref lm);
                    if (Node2Move != null)
                    {
                        /* Rotate Character */
                        var direction = (Node2Move.gameObject.transform.position - gameObject.transform.position).normalized;
                        Quaternion rotation = Quaternion.identity;

                        if (direction.x > 0.5f) rotation = Quaternion.Euler(0, 90, 0);
                        else if (direction.x < -0.5f) rotation = Quaternion.Euler(0, -90, 0);
                        else if (direction.z > 0.5f) rotation = Quaternion.Euler(0, 0, 0);
                        else if (direction.z < -0.5f) rotation = Quaternion.Euler(0, 180, 0);

                        gameObject.transform.DORotateQuaternion(rotation, RotationMovement);

                        if (Node2Move == gn)
                        {
                            gameObject.transform.DOMove(Node2Move.gameObject.transform.position, MovementDuration);
                            currentNode = Node2Move;
                            gn = null;
                        }
                        else
                        {
                            gameObject.transform.DOMove(Node2Move.gameObject.transform.position, MovementDuration);
                            currentNode = Node2Move;
                        }
                    }
                }
            }
            
        }
    }
}