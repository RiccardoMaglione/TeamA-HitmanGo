using DG.Tweening;
using HGO.ai;
using HGO.core;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyAttack : StateMachineBehaviour
{
    List<AI_Controller> enemies = new List<AI_Controller>();
    PlayerController pc;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemies = FindObjectsOfType<AI_Controller>().ToList();
        if (!pc) pc = FindObjectOfType<PlayerController>();

        foreach (AI_Controller AI in enemies)
        {
            if(AI.CheckObservedNode(pc.movementComponent.targetNode) && AI.behaviour != AI_STATE.NONE)
            {   
                var direction = (pc.gameObject.transform.position - AI.transform.position).normalized;
                pc.gameObject.transform.DOMove(pc.gameObject.transform.position + direction * 1f, 0.1f);
                AI.AI_ATTACK();
                animator.SetTrigger("Play Player Death Animation");
                return;
                
            }
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Check Player Node");
    }
}