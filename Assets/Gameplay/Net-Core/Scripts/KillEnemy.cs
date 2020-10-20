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

        foreach(AI_Controller ai in pc.PM.NC.nodeData.overlappedEnemies)
        {
            ai.gameObject.transform.DOJump(ai.gameObject.transform.position + new Vector3(0, 0, 20), 10, 1, 0.8f);
            ai.eyes.UnregisterForwardNode();
            //ai.gameObject.GetComponent<EnemyCemetery>().PlayDeathAnimation();
        }

    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}