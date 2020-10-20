using HGO.ai;
using HGO.core;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckNode :  StateMachineBehaviour
{
    PlayerController pc;
    List<AI_Controller> enemies;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!pc) pc = FindObjectOfType<PlayerController>();
        Debug.Log("1");
        enemies = new List<AI_Controller>();
        Debug.Log("2");
        enemies = FindObjectsOfType<AI_Controller>().ToList();
        Debug.Log("3");

        Debug.LogWarning($"enemies count: {enemies.Count}");
        Debug.Log("4");
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Controlla se il giocatore si trova sulla cella di fine livello
        if (pc.PM.NC is EndNode)
        {
            Debug.Log("5");
            animator.SetTrigger("Complete Level");
            return;
        }
        else if (pc.PM.NC is ItemNode)
        {
            Debug.Log("6");
            animator.SetTrigger("Throw Item");
            return;
        }
        else if (pc.PM.NC.nodeData.overlappedEnemiesCount >= 1)
        {
            Debug.Log("7");
            animator.SetTrigger("Kill Enemy");
            return;
        }
        else if (enemies.Count > 0)
        {
            Debug.Log("12");
            // Controlla se la cella raggiunta e' osservata da qualche nemico
            foreach (AI_Controller ai in enemies)
            {
                Debug.Log("13");
                if (ai.eyes.forwardNode == pc.PM.NC)
                {
                    Debug.Log("8");
                    animator.SetTrigger("Enemy Attack");
                    return;
                }
            }
        }
        else if(enemies.Count > 0)
        {
            Debug.Log("9");
            Debug.LogError("Enemy Check!!!");
            animator.SetTrigger("Check Enemy Status");
            return;
        }
        else
        {
            Debug.Log("10");
            animator.SetTrigger("Start Player Round");
            return;
        }
        Debug.Log("11");

    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Move Player");
    }
}