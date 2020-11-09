using HGO.ai;
using HGO.core;
using System.Linq;
using UnityEngine;

public class RegisterForwardNode : StateMachineBehaviour
{
    PlayerController pc;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!pc) pc = FindObjectOfType<PlayerController>();

        foreach(AI_Controller ai in FindObjectsOfType<AI_Controller>().ToList())
        {
            if (ai.behaviour != AI_STATE.NONE && ai.eyes.forwardNode != null)
            {
                ai.eyes.RegisterForwardNode();
                if(pc.movementComponent.currentNode == ai.eyes.forwardNode)
                {
                    animator.SetTrigger("Check Player Node");
                    return;
                }
            }
        }




        animator.SetTrigger("Start Player Round");
        return;
    }
}