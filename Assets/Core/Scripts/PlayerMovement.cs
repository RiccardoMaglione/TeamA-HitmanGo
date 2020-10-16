using DG.Tweening;
using HGO.core;
using UnityEngine;

namespace HGO
{

    public enum movement_direction
    {
        NULL,
        UP,
        RIGHT,
        DOWN,
        LEFT
    }

    public class PlayerMovement : MonoBehaviour
    {
        public Node selfNode;
        LevelManager lm;
        Vector3 prevPosition;
        Vector3 lastPosition;
        Vector3 targetPosition;
        Vector3 direction { get { return (lastPosition - prevPosition).normalized; } }
        bool playerHolded;



        private void Awake()
        {
            if(!Init())
            {
                Debug.LogError($"Attention! {gameObject.name}->Init(): can't initialze!\n");
                Application.Quit();
            }
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                prevPosition = Input.mousePosition;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.GetComponent<PlayerController>())
                    {
                        playerHolded = true;
                        gameObject.transform.DOMoveY(2, 0.25f);
                    }
                }
            }

            if(Input.GetMouseButtonUp(0))
            {
                if (playerHolded)
                {
                    lastPosition = Input.mousePosition;
                    Move(selfNode);
                }
                playerHolded = false;
                
            }

            if(!playerHolded && gameObject.transform.position == targetPosition)
            {
                gameObject.transform.DOMoveY(1f, 0.5f);
            }
        }
        /// <summary>
        /// Resituisce uno dei 4[NORD, SUD, EST, OVEST] vettori noti in base al parametro fornito
        /// </summary>
        movement_direction TranslateDirection(Vector3 dir)
        {

            if (dir.x > 0.5) return movement_direction.RIGHT;
            else if (dir.x < -0.5) return movement_direction.LEFT;
            else if (dir.y > 0.5) return movement_direction.UP;
            else if (dir.y < -0.5) return movement_direction.DOWN;
            else return movement_direction.NULL; 
        }

        /// <summary>
        /// Restituisce il primo nodo nella direzione in cui il personaggio vuole muoversi
        /// </summary>
        /// <param name="dir">direzione tracciata</param>
        /// <param name="node"> nodo dove si trova il giocatore</param>
        /// <returns></returns>
        core.Node FindNode(movement_direction dir, core.Node node)
        {
            switch (dir)
            {
                case movement_direction.NULL:
                    return null;
                case movement_direction.UP:

                    if(node.data.connections.up)
                    {
                        foreach(Node n in lm.levelNodes)
                        {
                            if (n.data.index == new Vector2(0, node.data.index.y +1))
                            {
                                return n;
                            }
                            
                        }
                    }
                    return null;
                case movement_direction.RIGHT:

                    if (node.data.connections.right)
                    {
                        foreach (Node n in lm.levelNodes)
                        {
                            if (n.data.index == new Vector2(node.data.index.x + 1, 0))
                            {
                                return n;
                            }

                        }
                    }
                    return null;
                case movement_direction.DOWN:

                    if (node.data.connections.down)
                    {
                        foreach (Node n in lm.levelNodes)
                        {
                            if (n.data.index == new Vector2(0, node.data.index.y - 1))
                            {
                                return n;
                            }

                        }
                    }
                    return null;
                case movement_direction.LEFT:
                    if (node.data.connections.left)
                    {
                        foreach (Node n in lm.levelNodes)
                        {
                            if (n.data.index == new Vector2(node.data.index.x - 1, 0))
                            {
                                return n;
                            }

                        }
                    }
                    return null;
                default:
                    return null;
            }
        }

        void Move(core.Node current_node, float time = 0.5f)
        {
            Node foundNode = FindNode(TranslateDirection(direction), current_node);
            Debug.Log(foundNode);
            
            if(foundNode != null)
            {
                targetPosition = new Vector3(foundNode.gameObject.transform.position.x, 2, gameObject.transform.position.z);
                gameObject.transform.DOMove(targetPosition, time);
                selfNode = foundNode;
            }
            else
            {
                gameObject.transform.DOMoveY(1, 0.5f);
            }
        }

        bool Init()
        {
            lm = FindObjectOfType<LevelManager>();

            if(!lm || lm.levelNodes.Count == 0)
            {
                Debug.LogError($"Attention! {gameObject.name}: can't initialize level manager\n");
                return false;
            }

            if(selfNode == null)
            {
                Debug.LogError($"Attention! {gameObject.name}: You need set the [SelfNode]\n");
                return false;
            }

            return true;
        }
    }
}