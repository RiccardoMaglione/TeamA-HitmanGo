using HGO.core;
using UnityEngine;

public class MovePlayer : StateMachineBehaviour
{
    PlayerController pc;
    static public bool CanMove;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!pc) pc = FindObjectOfType<PlayerController>(); 
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(CanMove == true) //Deve essere eseguito solo una volta, altrimenti continua a cadere finché non esce dall'update
        {
            pc.PM.Move();
            CanMove = false;
        }
        
        if (pc.gameObject.transform.position == pc.PM.endPosition)
        {
            animator.SetTrigger("Check Player Node");
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Move Player");
    }
}