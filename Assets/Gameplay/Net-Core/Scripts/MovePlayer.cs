using HGO.core;
using UnityEngine;

public class MovePlayer : StateMachineBehaviour
{
    PlayerController pc;
    static public bool CanMove;
    Node previousNode;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!pc) pc = FindObjectOfType<PlayerController>();
        previousNode = pc.PM.NC;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(CanMove == true) //Deve essere eseguito solo una volta, altrimenti continua a cadere finché non esce dall'update
        {
            pc.PM.Move();
            CanMove = false;
        }

        if (pc.PM.NC == previousNode)
        {
            animator.SetTrigger("Start Player Round");
            return;
        }
        else
        {
            animator.ResetTrigger("Start Player Round");
            animator.SetTrigger("Check Player Node");
            return;
        }
        
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Start Player Round");
    }
}