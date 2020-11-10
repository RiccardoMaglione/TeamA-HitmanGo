using DG.Tweening;
using HGO.core;
using HGO.core.data;
using UnityEngine;

public class ThrowItem : StateMachineBehaviour
{
    ThrowingData data;
    GameObject obj;
    PlayerController pc;
    Node targetNode;
    

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!data) data =       Resources.Load("DATA/ThrowingSystem/ThrowingData") as ThrowingData;
        if (!obj) obj =         Resources.Load("Prefabs/Items/Default_ThrowingItem") as GameObject;
        if (!pc) pc =           FindObjectOfType<PlayerController>();

        targetNode = FindObjectOfType<LevelManager>().ThrowingSystemManager.selectedNode;

        obj = Instantiate(Resources.Load("Prefabs/Items/Default_ThrowingItem") as GameObject);
        obj.gameObject.transform.position = pc.gameObject.transform.position + Vector3.one * 2;

        /* ITEM LAUNCH */
        obj.transform.DOJump(targetNode.transform.position, data.launch_force, 1, data.throw_duration);
        AudioManager.instance.Play("Throw Sound");
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(obj)
        {
            if (obj.GetComponent<Item>().hitCell)
            {
                Destroy(obj);
                animator.SetTrigger("Show Noise Area");                               
                return;
            }

        }
        
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}