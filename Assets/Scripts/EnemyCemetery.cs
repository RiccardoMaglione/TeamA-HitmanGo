using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyCemetery : MonoBehaviour
{
    public GameObject[] FinalPosition;
    static public int CountEnemy = 0;

    public bool TouchEnemy0 = true;

    public float TranslateTimeY = 1;
    public float WaitTime = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(MoveFunctionDestroyZone());
        }
    }

    IEnumerator MoveFunctionDestroyZone()
    {
        float timeSinceStarted = 0f;
        transform.DOMoveY(transform.position.y + 10, TranslateTimeY);
        yield return new WaitForSeconds(WaitTime);
        transform.position = Vector3.Lerp(transform.position, new Vector3(FinalPosition[CountEnemy].transform.position.x, transform.position.y + 10, FinalPosition[CountEnemy].transform.position.z), 1);
        yield return new WaitForSeconds(WaitTime);
        while (true)
        {
            timeSinceStarted += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, FinalPosition[CountEnemy].transform.position, timeSinceStarted);

            // If the object has arrived, stop the coroutine
            if (transform.position == FinalPosition[CountEnemy].transform.position)
            {
                CountEnemy = CountEnemy + 1;
                yield break;
            }
    
            // Otherwise, continue next frame
            yield return null;
        }
    }
}
