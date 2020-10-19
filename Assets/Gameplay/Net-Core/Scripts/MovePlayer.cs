using HGO.core;
using UnityEngine;

public class MovePlayer : StateMachineBehaviour
{
    PlayerController pc;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!pc) pc = FindObjectOfType<PlayerController>(); 
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        pc.PM.Move();

        if(pc.gameObject.transform.position == pc.PM.endPosition)
        {
            animator.SetTrigger("Check Player Node");
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Move Player");
    }
}