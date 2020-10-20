using DG.Tweening;
using HGO.core;
using UnityEngine;

public class PlayPlayerDeathAnimation : StateMachineBehaviour
{
    PlayerController pc;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!pc) pc = FindObjectOfType<PlayerController>();

        pc.gameObject.transform.DORotate(new Vector3(0, 0, 90), 0.2f);
        animator.SetTrigger("Lose Level");
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Play Player Death Animation");
    }
}

