using HGO.core;
using UnityEngine;

public class ShowNoiseArea : StateMachineBehaviour
{
    LevelManager lm;
    Node noiseOriginNode;
    GameObject noiseArea;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!lm) lm = FindObjectOfType<LevelManager>();
        if (!noiseOriginNode) noiseOriginNode = FindObjectOfType<LevelManager>().ThrowingSystemManager.selectedNode;

        noiseArea = GameObject.Instantiate(Resources.Load("Prefabs/NoiseArea") as GameObject, noiseOriginNode.gameObject.transform);
        noiseArea.transform.position = noiseOriginNode.gameObject.transform.position + Vector3.up;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!noiseArea)
        {
            if (lm.ThrowingSystemManager.enemiesNoised.Count > 0)
            {
                animator.SetTrigger("Change Enemy Behaviour");
                return;
            }
            else
            {
                animator.SetTrigger("Check Enemy Status");
                return;
            }
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        noiseOriginNode = null;
    }
}