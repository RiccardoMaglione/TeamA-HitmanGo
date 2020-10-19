using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace HGO.core
{
    public class PlayerMovementPM : MonoBehaviour
    {
        bool HoldClick = false;
        bool FinishTranslate = true;

        [Tooltip("Value for time of translate between cell")] public float MovementTime = 0.5f;
        [Tooltip("Value for size of one unit")] public float UnitGrid = 1;

        Vector3 PosDown;
        Vector3 PosUp;
        Vector3 DirectionPos;
        internal Vector3 endPosition = Vector3.zero;

        public GameObject Player;
        public Node NC;
        public NodeData ND;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Node>() == true)
            {
                NC = other.gameObject.GetComponent<Node>();
                ND.connections.up =         NC.nodeData.connections.up;
                ND.connections.right =      NC.nodeData.connections.right;
                ND.connections.down =       NC.nodeData.connections.down;
                ND.connections.left =       NC.nodeData.connections.left;


            }
        }

        void Start()
        {
            if (UnitGrid != 1)
            {
                float ValSize = (float)UnitGrid / 2;
                print(ValSize);
                Player.GetComponent<BoxCollider>().size = new Vector3(ValSize, 1, ValSize);
            }
        }

        public bool SwipeAction()
        {
            #region Press
            if (Input.GetMouseButtonDown(0) && FinishTranslate == true)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null)
                    {
                        if (hit.collider.tag == "Player")
                        {
                            FinishTranslate = false;
                            PosDown = Input.mousePosition;
                            Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 0.5f, Player.transform.position.z);
                            Debug.Log("Press");
                            HoldClick = true;
                            return false;
                        }
                    }
                }
            }
            #endregion
            #region Not Press
            if (Input.GetMouseButtonUp(0) && HoldClick == true)
            {
                FinishTranslate = false;
                HoldClick = false;
                PosUp = Input.mousePosition;
                Debug.Log("Hold");
                DirectionPos = (PosUp - PosDown).normalized;
                DirectionPos.x = Mathf.Round(DirectionPos.x);
                DirectionPos.y = Mathf.Round(DirectionPos.y);

                return true;


            }
            #endregion

            return false;
        }
        /// <summary>
        /// sempre commentare le funzioni
        /// </summary>
        public void Move()
        {

            #region Move Direction
            if (Vector3.up == DirectionPos && ND.connections.up == true)
            {
                //ND.index.y += 1;
                Debug.Log("Up");
                Player.transform.DOMove(Player.transform.position + Vector3.forward * UnitGrid, MovementTime);
                StartCoroutine(Timer());
                DirectionPos = new Vector3(0, 0, 0);
                endPosition = Player.transform.position + Vector3.forward * UnitGrid;
            }
            else if (Vector3.down == DirectionPos && ND.connections.down == true)
            {
                //ND.index.y -= 1;
                Debug.Log("Down");
                Player.transform.DOMove(Player.transform.position + Vector3.back * UnitGrid, MovementTime);
                StartCoroutine(Timer());
                DirectionPos = new Vector3(0, 0, 0);
                endPosition = Player.transform.position + Vector3.back * UnitGrid;

            }
            else if (Vector3.right == DirectionPos && ND.connections.right == true)
            {
                //ND.index.x += 1;
                Debug.Log("Right");
                Player.transform.DOMove(Player.transform.position + DirectionPos * UnitGrid, MovementTime);
                StartCoroutine(Timer());
                DirectionPos = new Vector3(0, 0, 0);
                endPosition = Player.transform.position + DirectionPos * UnitGrid;
            }
            else if (Vector3.left == DirectionPos && ND.connections.left == true)
            {
                //ND.index.x -= 1;
                Debug.Log("Left");
                Player.transform.DOMove(Player.transform.position + DirectionPos * UnitGrid, MovementTime);
                StartCoroutine(Timer());
                DirectionPos = new Vector3(0, 0, 0);
                endPosition = Player.transform.position + DirectionPos * UnitGrid;
            }
            else
            {
                //Questo punto andava in update
                Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y - 0.5f, Player.transform.position.z);
                FinishTranslate = true;
            }
            #endregion
        }
        IEnumerator Timer()
        {
            yield return new WaitForSeconds(MovementTime);
            Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y - 0.5f, Player.transform.position.z);
            FinishTranslate = true;
        }
    }
}