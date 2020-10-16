using System.Collections;
using UnityEngine;
using DG.Tweening;

public class GridMove : MonoBehaviour
{
    #region Variables
    bool HoldClick = false;
    bool FinishTranslate = true;
    
    [Tooltip("Value for time of translate between cell")] public float TranslateTime = 1f;
    [Tooltip("Value for size of one unit")] public int UnitGrid = 1;
    
    Vector3 PosDown;
    Vector3 PosUp;
    Vector3 DirectionPos;
    
    public GameObject Player;
    #endregion

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

        if (Input.GetMouseButtonUp(0) && HoldClick == true)
        {
            FinishTranslate = false;
            HoldClick = false;
            PosUp = Input.mousePosition;
            Debug.Log("Hold");
            DirectionPos = (PosUp - PosDown).normalized;
            DirectionPos.x = Mathf.Round(DirectionPos.x);
            DirectionPos.y = Mathf.Round(DirectionPos.y);
            
            #region Move Direction
            if (Vector3.up == DirectionPos && CellCheck.UnlockNord == true)
            {
                CellCheck.UnlockNord = false;
                CellCheck.UnlockSud = false;
                CellCheck.UnlockEst = false;
                CellCheck.UnlockOvest = false;
                Debug.Log("Up");
                Player.transform.DOMove(Player.transform.position + Vector3.forward * UnitGrid, TranslateTime);
                StartCoroutine(Timer());
                DirectionPos = new Vector3(0, 0, 0);
            }
            else if (Vector3.down == DirectionPos && CellCheck.UnlockSud == true)
            {
                CellCheck.UnlockNord = false;
                CellCheck.UnlockSud = false;
                CellCheck.UnlockEst = false;
                CellCheck.UnlockOvest = false;
                Debug.Log("Down");
                Player.transform.DOMove(Player.transform.position + Vector3.back * UnitGrid, TranslateTime);
                StartCoroutine(Timer());
                DirectionPos = new Vector3(0, 0, 0);
            }
            else if (Vector3.right == DirectionPos && CellCheck.UnlockEst == true)
            {
                CellCheck.UnlockNord = false;
                CellCheck.UnlockSud = false;
                CellCheck.UnlockEst = false;
                CellCheck.UnlockOvest = false;
                Debug.Log("Right");
                Player.transform.DOMove(Player.transform.position + DirectionPos * UnitGrid, TranslateTime);
                StartCoroutine(Timer());
                DirectionPos = new Vector3(0, 0, 0);
            }
            else if (Vector3.left == DirectionPos && CellCheck.UnlockOvest == true)
            {
                CellCheck.UnlockNord = false;
                CellCheck.UnlockSud = false;
                CellCheck.UnlockEst = false;
                CellCheck.UnlockOvest = false;
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
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(TranslateTime);
        Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y - 0.5f, Player.transform.position.z);
        FinishTranslate = true;
    }
}