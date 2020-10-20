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
            if (ai.eyes.forwardNode == pc.PM.NC)
            {
                bcanAttack = true;
                break;
            }
        }

    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Controlla se il giocatore si trova sulla cella di fine livello
        if (pc.PM.NC is EndNode)
        {
            animator.SetTrigger("Complete Level");
            return;
        }
        else if (pc.PM.NC is ItemNode)
        {
            animator.SetTrigger("Throw Item");
            return;
        }
        else if (pc.PM.NC.nodeData.overlappedEnemiesCount >= 1)
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

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Move Player");
        bcanAttack = false;
    }
}