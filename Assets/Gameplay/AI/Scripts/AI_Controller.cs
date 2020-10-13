using DG.Tweening;
using System;
using UnityEngine;

namespace HGO
{
    namespace ai
    {
        public class AI_Controller : core.CharacterController
        {
            [Header("Settings"), Space(5)]
            public float MovementDuration = 0.5f;
            AI_Vision eyes;

            #region UnityCallbacks
            protected void Awake()
            {
                if (!eyes) eyes = gameObject.GetComponent<AI_Vision>();

                #region events subscription
                //do some stuff
                #endregion 
            }
            public void Update()
            {
                if(Input.GetKeyDown(KeyCode.Space)) //CANCELLARE - SOLO TESTING
                {
                    eyes.RegisterNode();
                    gameObject.transform.DOMove(eyes.forwardNode.gameObject.transform.position + new Vector3(0,1,0), MovementDuration);
                    eyes.currentNode = eyes.forwardNode;
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

        }
    }
}