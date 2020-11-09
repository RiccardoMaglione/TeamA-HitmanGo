using HGO.ai;
using HGO.core;
using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;
using System.Linq;

public class MoveEnemy : StateMachineBehaviour
{
    LevelManager level;
    List<AI_Controller> movingEnemies = new List<AI_Controller>();

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Controlla tutte i personaggi che si devono muovere
        // Verifica i personaggi che si devono muovere su di una stessa cella
        // Verifica le direzioni da cui vengono questi personaggi
        // Se: 2 personaggi da direzioni opposte
        // Se: 3+ personaggi 

        movingEnemies.Clear();

        if (!level) level = FindObjectOfType<LevelManager>();

        /*Registra i nemici che si devono muovere*/
        foreach(AI_Controller ai in level.levelEnemies)
        {
            if (ai.waitedRound == 1)
            {
                movingEnemies.Add(ai);
            }
            else if(ai.behaviour == AI_STATE.PATROL && ai.waitedRound == 0)
            {
                ai.waitedRound += 1;
            }
        }

        if (movingEnemies.Count > 0)
        {

            foreach(AI_Controller ai in movingEnemies)
            {
                ai.AI_MOVE();
            }

        }

        animator.SetTrigger("Clear NPC Position");
        return;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach(AI_Controller ai in movingEnemies)
        {
            if (ai.eyes.currentNode == ai.goalNode || ai.currentNode == ai.goalNode)
            {
                ai.questionTag.SetActive(false);
                ai.goalNode = null;
            }
        }
    }



}