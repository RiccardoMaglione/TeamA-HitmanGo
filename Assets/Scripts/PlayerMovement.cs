using UnityEngine;
using DG.Tweening;
using HGO.ai;

namespace HGO.core
{
    [RequireComponent(typeof(PlayerController))]
    public sealed class PlayerMovement : MonoBehaviour
    {
        private bool canMove = true;

        LevelManager lvManager;
        internal Node currentNode;                                          // Nodo sul quale il personaggio si trovo al momento
        internal Node targetNode;                                           // Nodo dove deve andare il giocatore
        internal Vector3 targetPosition                                     // Coordinate del nodo che dobbiamo raggiungere
        {
            get
            {
                if (targetNode) return targetNode.gameObject.transform.position;
                else return Vector3.zero;
            }
        }
        Vector3 startPoint;                                                 // Primo Punto d'iterazione del mouse
        Vector3 endPoint;                                                   // Secondo Punto d'iterazione del mouse
        Vector3[] movementPath
        {
            get
            {
                Vector3[] path = new Vector3[2];
                path[0] = new Vector3(targetPosition.x, characterSelectionHeight, targetPosition.z);
                path[1] = new Vector3(targetPosition.x, characterDeselectionHeight, targetPosition.z);

                return path;
            }
        }
        internal Vector3 swipeDirection                                     // La direzione traccia dal giocatore sullo schermo
        { 
            get
            {
                var direction = (endPoint - startPoint).normalized;

                if (direction.x != 1 || direction.x != -1) direction.x = Mathf.Round(direction.x);
                if (direction.y != 1 || direction.y != -1) direction.y = Mathf.Round(direction.y);

                return new Vector3(direction.x, 0, direction.y);
            }
        }
        internal Vector3 tappedDirection;                                   // La direzione precedentemente tracciata
        bool HoldedCharacter = false;                                       // Rappresenta la pressione dell'input da parte dell'utente
        internal bool MovementCompleted                                     // Definisce se l'animazione di movimento e' stato completata
        {
            get
            {
                return gameObject.transform.position == movementPath[0];
            }
        }

        [Header("Selection Animation"), Space(5)]
        [Tooltip("Definisce la massima altezza che un personaggio puo raggiungere quando viene selezionato")]
        public float characterSelectionHeight = 2;
        [Tooltip("Definisce in quanto tempo il personaggio raggiunge l'altezza desiderata in secondi")]
        public float selectionAnimationTime = 0.25f;

        [Header("Deselection Animartion"), Space(5)]
        [Tooltip("Definisce la massima altezza che un personaggio deve raggiungere quando viene deselezionato")]
        public float characterDeselectionHeight = 1;
        [Tooltip("Definisce in quanti tempo il personaggio raggiunge l'altezza desiderata in secondi")]
        public float deselectionAnimationTime = 0.25f;

        [Header("Movement Animation"), Space(5)]
        [Tooltip("Definisce in quanto tempo il giocatore raggiunge la destinazione finale")]
        public float movementAnimationTime = 0.5f;

        /// <summary>
        /// Initialize movement component
        /// </summary>
        /// <param name="lm">Level Manager</param>
        public void Init(ref LevelManager lm, ref Node currentNode)
        {
            lvManager = lm;
            this.currentNode = currentNode;
        }
        /// <summary>
        /// Returns TRUE if the movement trajectory is valid otherwise FALSE
        /// </summary>
        /// <returns></returns>
        public bool SwipeAction()
        {
            if (canMove)
            {

                if (Input.GetMouseButtonDown(0))
                {
                    Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(r, out hit))
                    {
                        if (hit.collider.gameObject.GetComponent<PlayerController>())
                        {
                            Debug.LogWarning(hit.collider.name);
                            startPoint = Input.mousePosition;
                            HoldedCharacter = true;

                            gameObject.transform.DOMoveY(characterSelectionHeight, selectionAnimationTime);
                        }
                    }

                }

                if (Input.GetMouseButtonUp(0) && HoldedCharacter)
                {
                    endPoint = Input.mousePosition;

                    /* Controllo se la direzione selezionata e' valida*/
                    if (IsValidDirection())
                    {
                        targetNode = Pathfinder.GetNeighbourNode(ref lvManager, swipeDirection, currentNode);

                        tappedDirection = swipeDirection;           // Registro la direzione tracciata prima di annullarla

                        /* Blocco movimenti della pre-registrazione delle variabili */
                        startPoint = Vector3.zero;
                        endPoint = Vector3.zero;

                        HoldedCharacter = false;

                        return true;
                    }
                    else
                    {
                        gameObject.transform.DOMoveY(characterDeselectionHeight, deselectionAnimationTime);

                        startPoint = Vector3.zero;
                        endPoint = Vector3.zero;

                        HoldedCharacter = false;

                        return false;
                    }


                }
            }
            return false;
        }
        public void Move()
        {

            gameObject.transform.DOMove(movementPath[0], movementAnimationTime);
            if (gameObject.transform.position == movementPath[0])
            {
                gameObject.transform.DOMove(movementPath[1], 0.1f, true);
            }
          
        }
        public void UpdateCurrentNode() { currentNode = targetNode; }
        public void PlaySelectionAnimation()
        {
            gameObject.transform.DOMoveY(characterSelectionHeight, selectionAnimationTime);
        }
        public void PlayeDeselectionAnimation()
        {
            gameObject.transform.DOMoveY(characterDeselectionHeight, deselectionAnimationTime);
        }
        bool IsValidDirection()
        {
            if (swipeDirection == Vector3.forward && currentNode.nodeData.connections.up)                       return true;
            else if (swipeDirection == Vector3.right && currentNode.nodeData.connections.right)                 return true;
            else if (swipeDirection == Vector3.back && currentNode.nodeData.connections.down)                   return true;
            else if (swipeDirection == Vector3.left && currentNode.nodeData.connections.left)                   return true;

            return false;
        }

        public void Enable()
        {
            canMove = true;
        }

        public void Disable()
        {
            canMove = false;
        }
    }    
}