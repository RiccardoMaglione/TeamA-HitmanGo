using HGO.core;
using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

public class ClearNPCPosition : StateMachineBehaviour
{
    LevelManager level;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!level) level = FindObjectOfType<LevelManager>();

        foreach(Node n in level.levelNodes)
        {
            if(n.nodeData.overlappedEnemiesCount == 2)
            {
                Debug.LogError("Due nemici sulla stessa cella");

                n.nodeData.overlappedEnemies[0].transform.DOKill();
                n.nodeData.overlappedEnemies[1].transform.DOKill();

                n.nodeData.overlappedEnemies[0].gameObject.transform.DOMove(n.gameObject.transform.position - (n.gameObject.transform.position - n.nodeData.overlappedEnemies[0].gameObject.transform.position).normalized, 0.15f);
                n.nodeData.overlappedEnemies[1].gameObject.transform.DOMove(n.gameObject.transform.position - (n.gameObject.transform.position - n.nodeData.overlappedEnemies[1].gameObject.transform.position).normalized, 0.15f);
            }
            else if(n.nodeData.overlappedEnemiesCount >= 3)
            {
                float degs = 360f / n.nodeData.overlappedEnemiesCount;
                List<Vector3> positions = CalculatePositions(n, n.nodeData.overlappedEnemiesCount, degs);

                for(int i = 0; i < positions.Count; i++)
                {
                    n.nodeData.overlappedEnemies[i].gameObject.transform.DOKill();
                    n.nodeData.overlappedCharacters[i].gameObject.transform.DOMove(positions[i], 0.15f);
                }
            }
        }

        animator.SetTrigger("Register Forward Node");
        return;
    }

    private static List<Vector3> CalculatePositions(Node n, int totalEnemies, float degs)
    {
        List<Vector3> positions = new List<Vector3>();

        // Calcola nuove posizioni
        for (int i = 1; i <= totalEnemies; i++)
        {
            float d = degs * i;
            var direction = Quaternion.Euler(0, d, 0) * (n.gameObject.transform.position + Vector3.forward - n.gameObject.transform.position);
            //Debug.LogError($"{i}. {direction}");
            positions.Add(n.gameObject.transform.position + direction);
        }

        return positions;
    }
}