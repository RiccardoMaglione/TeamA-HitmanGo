using HGO.ai;
using HGO.core;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckNode :  StateMachineBehaviour
{
    PlayerController pc;
    List<AI_Controller> enemies;
    bool bcanAttack;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!pc) pc = FindObjectOfType<PlayerController>();
        enemies = new List<AI_Controller>();
        enemies = FindObjectsOfType<AI_Controller>().ToList();

        foreach (AI_Controller ai in enemies)
        {
            if (ai.eyes.forwardNode == pc.movementComponent.targetNode)
            {
                if(ai.currentNode) bcanAttack = true;
                break;
            }
        }
        
        if (pc.movementComponent.targetNode is EndNode)                                // Controlla se il giocatore si trova sulla cella di fine livello
        {
            animator.SetTrigger("Complete Level");
            return;
        }
        else if (pc.movementComponent.targetNode is ItemNode)                          // Controlla se mi trovo su di un nodo che permette il lancio di un oggetto
        {
            if (pc.movementComponent.targetNode.gameObject.GetComponent<ItemNode>().activated)
            {
                animator.SetTrigger("Wait Throw Selection");
                return;
            }
            else
            {
                animator.SetTrigger("Check Enemy Status");
                return;
            }
        }
        else if (pc.movementComponent.targetNode.nodeData.overlappedEnemiesCount >= 1)
        {
            animator.SetTrigger("Kill Enemy");
            return;
        }
        else if (bcanAttack)
        {
            animator.SetTrigger("Enemy Attack");
            return;
        }
        else if(enemies.Count > 0)
        {
            animator.SetTrigger("Check Enemy Status");
            return;
        }
        else
        {
            animator.SetTrigger("Start Player Round");
            return;
        }

    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Move Player");
        bcanAttack = false;
    }
}