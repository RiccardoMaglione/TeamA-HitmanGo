using DG.Tweening;
using HGO.ai;
using HGO.core;
using TMPro;
using UnityEngine;


public class WaitPlayerInput : StateMachineBehaviour
{
    PlayerController pc;
    LevelManager lm;
    public static Node waitNode;
    public static bool detectNode = true;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!pc) pc = FindObjectOfType<PlayerController>();
        if (!lm) lm = FindObjectOfType<LevelManager>();
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

            Node targetNode = null;
            /*Check Swipe Direction*/
            if (pc.PM.normalDirection == Vector3.forward) targetNode = Pathfinder.GetNeighbourNode(ref lm, AI_ORIENTATION.up, pc.PM.NC);
            else if (pc.PM.normalDirection == Vector3.right) targetNode = Pathfinder.GetNeighbourNode(ref lm, AI_ORIENTATION.right, pc.PM.NC);
            else if (pc.PM.normalDirection == Vector3.down) targetNode = Pathfinder.GetNeighbourNode(ref lm, AI_ORIENTATION.down, pc.PM.NC);
            else if (pc.PM.normalDirection == Vector3.left) targetNode = Pathfinder.GetNeighbourNode(ref lm, AI_ORIENTATION.left, pc.PM.NC);

            // Se un nemico si trova sulla cella si deve spostare prima di essere ucciso
            if(targetNode != null && targetNode.nodeData.overlappedEnemiesCount >= 1)
            {
                foreach(AI_Controller ai in targetNode.nodeData.overlappedEnemies)
                {
                    ai.gameObject.transform.DOMove(ai.gameObject.transform.position + (ai.gameObject.transform.position - pc.gameObject.transform.position).normalized * 1f, 0.2f);
                }
            }

            targetNode = null;

            return;
        }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Start Player Round");
    }

   
}
