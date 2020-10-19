using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.EventSystems;
using DG.Tweening;
using HitmanGo.NodeGo;
public class PlayerMovementPM : MonoBehaviour
{
    #region Variables
    bool HoldClick = false;
    bool FinishTranslate = true;
    
    [Tooltip("Value for time of translate between cell")] public float TranslateTime = 1f;
    [Tooltip("Value for size of one unit")] public float UnitGrid = 1;
    
    Vector3 PosDown;
    Vector3 PosUp;
    Vector3 DirectionPos;
    
    public GameObject Player;
    public NodeCell NC;
    public NodeData ND;
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<NodeCell>() == true)
        {
            NC = other.gameObject.GetComponent<NodeCell>();
            ND.sconnections.Nord = NC.nodeData.sconnections.Nord;
            ND.sconnections.Sud = NC.nodeData.sconnections.Sud;
            ND.sconnections.Est = NC.nodeData.sconnections.Est;
            ND.sconnections.Ovest = NC.nodeData.sconnections.Ovest;
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
    void Update()
    {
        SwipeAction();
    }

    public void SwipeAction()
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

            Move();
        }
        #endregion
    }
    public void Move()
    {
        #region Move Direction
        if (Vector3.up == DirectionPos && ND.sconnections.Nord == true)
        {
            //ND.index.y += 1;
            Debug.Log("Up");
            Player.transform.DOMove(Player.transform.position + Vector3.forward * UnitGrid, TranslateTime);
            StartCoroutine(Timer());
            DirectionPos = new Vector3(0, 0, 0);
        }
        else if (Vector3.down == DirectionPos && ND.sconnections.Sud == true)
        {
            //ND.index.y -= 1;
            Debug.Log("Down");
            Player.transform.DOMove(Player.transform.position + Vector3.back * UnitGrid, TranslateTime);
            StartCoroutine(Timer());
            DirectionPos = new Vector3(0, 0, 0);
        }
        else if (Vector3.right == DirectionPos && ND.sconnections.Est == true)
        {
            //ND.index.x += 1;
            Debug.Log("Right");
            Player.transform.DOMove(Player.transform.position + DirectionPos * UnitGrid, TranslateTime);
            StartCoroutine(Timer());
            DirectionPos = new Vector3(0, 0, 0);
        }
        else if (Vector3.left == DirectionPos && ND.sconnections.Ovest == true)
        {
            //ND.index.x -= 1;
            Debug.Log("Left");
            Player.transform.DOMove(Player.transform.position + DirectionPos * UnitGrid, TranslateTime);
            StartCoroutine(Timer());
            DirectionPos = new Vector3(0, 0, 0);
        }
        else
        {
            Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y - 0.5f, Player.transform.position.z);
            FinishTranslate = true;
        }
        #endregion
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(TranslateTime);
        Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y - 0.5f, Player.transform.position.z);
        FinishTranslate = true;
    }
}