using HGO.ai;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemyState : StateMachineBehaviour
{
    List<AI_Controller> enemies = new List<AI_Controller>();

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemies = FindObjectsOfType<AI_Controller>().ToList();

        foreach(AI_Controller ai in enemies)
        {
            if(ai.behaviour == AI_STATE.PATROL)
            {
                animator.SetTrigger("Move Enemy");
                return;
            }
        }

        animator.SetTrigger("Start Player Round");
        return;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Check Enemy Status");
    }
}