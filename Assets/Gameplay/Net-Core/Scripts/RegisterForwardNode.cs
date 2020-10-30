using HGO.ai;
using System.Linq;
using UnityEngine;

public class RegisterForwardNode : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach(AI_Controller ai in FindObjectsOfType<AI_Controller>().ToList())
        {
            if (ai.behaviour != AI_STATE.NONE && ai.eyes.forwardNode != null)
            {
                ai.eyes.RegisterForwardNode();
            }
        }

        animator.SetTrigger("Start Player Round");
        return;
    }
}