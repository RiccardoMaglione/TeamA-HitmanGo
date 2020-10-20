using DG.Tweening;
using System.Collections;
using UnityEngine;

public class EnemyCemetery : MonoBehaviour
{
    public GameObject[] FinalPosition;
    static public int CountEnemy = 0;

    public bool enemyHitted = true;

    public float TranslateTimeY = 1;
    public float maxCharacterHeight = 5;
    public float WaitTime = 1;

    private void OnTriggerEnter(Collider other)
    {
        enemyHitted = true;
        //if (other.gameObject.tag == "Player")
        //{
        //    PlayDeathAnimation();
        //    //gameObject.transform.DOJump(FinalPosition[0].transform.position , 10, 1, TranslateTimeY);
        //}
    }

    public void PlayDeathAnimation()
    {
        StartCoroutine(MoveToCemeteryArea());
    }

    IEnumerator MoveToCemeteryArea()
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
