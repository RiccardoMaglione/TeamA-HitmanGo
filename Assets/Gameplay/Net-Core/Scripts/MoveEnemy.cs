using HGO.ai;
using HGO.core;
using UnityEngine;

public class MoveEnemy : StateMachineBehaviour
{
    LevelManager level;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Controlla tutte i personaggi che si devono muovere
        // Verifica i personaggi che si devono muovere su di una stessa cella
        // Verifica le direzioni da cui vengono questi personaggi

        if (!level) level = FindObjectOfType<LevelManager>();
        foreach(AI_Controller ai in level.levelEnemies)
        {
            if (ai.waitedRound == 1)
            {
                ai.AI_MOVE();
                ai.waitedRound = 0;
            }
            else if(ai.behaviour == AI_STATE.PATROL && ai.waitedRound == 0)
            {
                ai.waitedRound += 1;
            }
        }

        animator.SetTrigger("Start Player Round");
        return;
    }
}