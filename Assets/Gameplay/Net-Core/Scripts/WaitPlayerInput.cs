using HGO.core;
using TMPro;
using UnityEngine;


public class WaitPlayerInput : StateMachineBehaviour
{
    PlayerController pc;
    public static Node waitNode;
    public static bool detectNode = true;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!pc) pc = FindObjectOfType<PlayerController>();
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(detectNode == true)
        {
            waitNode = pc.PM.NC; //cell1
            detectNode = false;
        }
        if (pc.PM.SwipeAction())
        {
            animator.SetTrigger("Move Player");
            MovePlayer.CanMove = true;
            return;
        }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Start Player Round");
    }

   
}
