using HGO.ai;
using HGO.core;
using UnityEngine;

public class ChangeEnemyStatus : StateMachineBehaviour
{
    LevelManager lm;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!lm) lm = FindObjectOfType<LevelManager>();

        /*Cambia lo stato di tutti i nemici che hanno sentito un rumore*/
        foreach(AI_Controller ai in lm.ThrowingSystemManager.enemiesNoised)
        {
            ai.AI_CHANGE_STATE(AI_STATE.PATROL);
            ai.goalNode = lm.ThrowingSystemManager.selectedNode;
            ai.AI_ROTATE(Pathfinder.GetNearestNodeOnPattern(ai.currentNode, ai.goalNode, ref lm));
            ai.questionTag.SetActive(true);
        }

        animator.SetTrigger("Check Enemy Status");
        return;
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        lm.ThrowingSystemManager.enemiesNoised.Clear();
        
    }
}