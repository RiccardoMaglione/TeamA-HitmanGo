using HGO.core;
using UnityEngine;

public class MovePlayer : StateMachineBehaviour
{
    PlayerController pc;
    LevelManager levelManager;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!pc) pc = FindObjectOfType<PlayerController>();
        if (!levelManager) levelManager = FindObjectOfType<LevelManager>();

        pc.movementComponent.Move();
        animator.SetTrigger("Check Player Node");
        return;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        pc.movementComponent.PlayeDeselectionAnimation();
        pc.movementComponent.UpdateCurrentNode();
        animator.ResetTrigger("Start Player Round");
    }
}