using DG.Tweening;
using HGO.core;
using System;
using UnityEngine;

namespace HGO
{
    namespace ai
    {
        public enum AI_STATE { NONE, SLEEP, PATROL}

        public class AI_Controller : core.CharacterController
        {
            [Header("Settings"), Space(5)]
            public float MovementDuration = 0.5f;
            public float RotationMovement = 0.5f;
            public Node gn; // da cancellare
            public Node currentNode; // da cancellare
            LevelManager lm;
            internal AI_Vision eyes;
            internal AI_STATE behaviour = AI_STATE.SLEEP;
            internal int waitedRound = 0;
            

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
            protected void OnDestroy()
            {
                eyes = null;
            }
            #endregion

            #region Events
            static Action OnPlayerDetected;
            #endregion

            #region Callbacks
            public bool CheckObservedNode(Node pNode)
            {
                if (eyes)
                {
                    if (eyes.forwardNode == pNode) return true;

                }

                return false;
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

            public void AI_ATTACK()
            {
                //eyes.RegisterForwardNode();
                gameObject.transform.DOMove(eyes.forwardNode.gameObject.transform.position + new Vector3(0,1,0), MovementDuration);
                eyes.currentNode = eyes.forwardNode;
            }

            public void AI_CHANGE_STATE(AI_STATE _newstate)
            {
                behaviour = _newstate;
            }
        }
    }
}