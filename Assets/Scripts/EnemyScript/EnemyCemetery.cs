using DG.Tweening;
using System.Collections;
using UnityEngine;

public class EnemyCemetery : MonoBehaviour
{
    [Tooltip("Insert a gameobjects that indicates a cemetery")]
    public GameObject[] FinalPosition;
    static public int CountEnemy = 0; //Count enemy for know a position of cemetery

    [Tooltip("Time for movement of enemy to up")]
    public float TimeMoveToUp = 1;
    [Tooltip("Time for movement of enemy horizontal")]
    public float TimeMoveToCemetery = 1;
    [Tooltip("Time for movement of enemy to down on position of cemetery")]
    public float TimeMoveToDown = 1;
    [Tooltip("Height reached by enemy in 'TimeMoveToUp'")]
    public float heightReached = 10;

    /// <summary>
    /// Method for movement of enemy from cell to cemetery
    /// </summary>
    public void EnemyToCemetery()
    {
        if (PlayerPrefs.GetInt("setSound") == 1)
            AudioManager.instance.Play("Kill Sound");
        
        Sequence MoveSequence = DOTween.Sequence(); //Initialize a sequence of DoTween
        MoveSequence.Append(transform.DOMoveY(transform.position.y + heightReached, TimeMoveToUp));
        print("Count Enemy" + CountEnemy);
        MoveSequence.Append(transform.DOMove(new Vector3(FinalPosition[CountEnemy].transform.position.x, transform.position.y + heightReached, FinalPosition[CountEnemy].transform.position.z), TimeMoveToCemetery));
        MoveSequence.Append(transform.DOMove(FinalPosition[CountEnemy].transform.position, TimeMoveToDown));
        CountEnemy = CountEnemy + 1;
    }
}