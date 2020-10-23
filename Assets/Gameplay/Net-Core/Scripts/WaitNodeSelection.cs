using HGO.core;
using HGO.core.data;
using System.Collections.Generic;
using UnityEngine;

public class WaitNodeSelection : StateMachineBehaviour
{
    List<Node> nearbyNodes = new List<Node>();
    LevelManager lm;
    ThrowingData data;
    PlayerController pc;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!lm) lm = FindObjectOfType<LevelManager>();
        if (!data) data = Resources.Load("DATA/ThrowingSystem/ThrowingData") as ThrowingData;
        if (!pc) pc = FindObjectOfType<PlayerController>();

        nearbyNodes = GetRangedNodes(ref lm);

        foreach(Node n in nearbyNodes)
        {
            n.gameObject.GetComponentInChildren<SpriteRenderer>().material.color = Color.red;           // Cambiare debug grafico nella release
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.GetComponent<Node>())
                {
                    var node = hit.collider.gameObject.GetComponent<Node>();
                    lm.ThrowingSystemManager.RegisterNode(ref node);

                    animator.SetTrigger("Throw Item");
                    return;
                }
            }
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach (Node n in nearbyNodes)
        {
            n.gameObject.GetComponentInChildren<SpriteRenderer>().material.color = Color.white;           // Cambiare debug grafico nella release
        }

        pc.movementComponent.currentNode.gameObject.GetComponent<ItemNode>().Disable();
    }

    List<Node> GetRangedNodes(ref LevelManager lm)
    {
        List<Node> list = new List<Node>();
        foreach(Node n in lm.levelNodes)
        {
            if(IsValid(n) && n != pc.movementComponent.currentNode)
            {
                list.Add(n);
            }
        }

        return list;
    }

    bool IsValid(Node node)
    {
        var playerNode = pc.movementComponent.currentNode.gameObject.transform.position;
        var n = node.gameObject.transform.position;

        return (n - playerNode).magnitude <= data.throw_area;
    }
}