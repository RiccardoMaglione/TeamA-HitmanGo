using DG.Tweening;
using HGO.ai;
using HGO.core;
using UnityEngine;


public class WaitPlayerInput : StateMachineBehaviour
{
    PlayerController pc;
    LevelManager lm;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!pc) pc = FindObjectOfType<PlayerController>();
        if (!lm) lm = FindObjectOfType<LevelManager>();

        foreach(AI_Controller ai in lm.levelEnemies)
        {
            ai.eyes.RegisterForwardNode();
        }

    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(pc.movementComponent.SwipeAction())
        {
            if(pc.movementComponent.targetNode.nodeData.overlappedEnemies.Count >= 1)           // Se sono presenti dei nemici sul nodo si devono spostare prima di essere sterminati
            {
                foreach(AI_Controller ai in pc.movementComponent.targetNode.nodeData.overlappedEnemies)
                {
                    ai.gameObject.transform.DOMove(ai.gameObject.transform.position + pc.movementComponent.tappedDirection, 0.25f);
                }
            }

            animator.SetTrigger("Move Player");
           
        }
       
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Start Player Round");
        
    }

   
}
