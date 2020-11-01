using DG.Tweening;
using HGO.ai;
using HGO.core;
using UnityEngine;

public class KillEnemy : StateMachineBehaviour
{
    PlayerController pc;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!pc) pc = FindObjectOfType<PlayerController>();

        foreach(AI_Controller ai in pc.movementComponent.targetNode.nodeData.overlappedEnemies)
        {
            //ai.gameObject.transform.DOJump(ai.gameObject.transform.position + new Vector3(0, 0, 20), 10, 1, 0.8f);
            ai.eyes.UnregisterForwardNode();
            ai.AI_CHANGE_STATE(AI_STATE.NONE);
            //ai.eyes.currentNode = null;
            ai.gameObject.GetComponent<EnemyCemetery>().EnemyToCemetery();
        }

        animator.SetTrigger("Check Enemy Status");

    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}