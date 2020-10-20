﻿using HGO.ai;
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

        enemies = new List<AI_Controller>();
        enemies = FindObjectsOfType<AI_Controller>().ToList();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Controlla se il giocatore si trova sulla cella di fine livello
        if (pc.PM.NC is EndNode) animator.SetTrigger("Complete Level");
        else if (pc.PM.NC is ItemNode) animator.SetTrigger("Throw Item");
        else if (pc.PM.NC.nodeData.overlappedEnemiesCount >= 1) animator.SetTrigger("Kill Enemy");
        else
        {
            // Controlla se la cella raggiunta e' osservata da qualche nemico
            foreach (AI_Controller ai in enemies)
            {
                if (ai.eyes.forwardNode == pc.PM.NC) animator.SetTrigger("Enemy Attack");
                break;
            }
        }
        
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}