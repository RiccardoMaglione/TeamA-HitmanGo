using HGO.core;
using UnityEngine;

public class MovePlayer : StateMachineBehaviour
{
    PlayerController pc;
    static public bool CanMove;
    public Node previousNode;
    public Node currentNode;

    public float timeLeft = 1f;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!pc) pc = FindObjectOfType<PlayerController>();
        //currentNode = pc.PM.NC;
        //previousNode = pc.PM.NC;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(CanMove == true && (PlayerMovementPM.DirectionPos == Vector3.up || PlayerMovementPM.DirectionPos == Vector3.down || PlayerMovementPM.DirectionPos == Vector3.left || PlayerMovementPM.DirectionPos == Vector3.right)) //Deve essere eseguito solo una volta, altrimenti continua a cadere finché non esce dall'update
        {
            Debug.Log("Prendo il nodo");
            pc.PM.Move();
            CanMove = false;

        }
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            previousNode = pc.PM.NC; //current quello prima di muoversi questo diventa cell2
            Debug.Log("Ci entri?");
            //if (pc.PM.NC == previousNode)
            if (previousNode == WaitPlayerInput.waitNode) //cell2 = cell1 no
            {
                Debug.Log("Sono uguali i nodi");
                animator.SetTrigger("Start Player Round");
                WaitPlayerInput.detectNode = true;
                timeLeft = 1;
                return;
            }
            else
            {
                Debug.Log("Sono diversi i nodi");
                animator.ResetTrigger("Start Player Round");
                animator.SetTrigger("Check Player Node");
                WaitPlayerInput.detectNode = true;
                timeLeft = 1;
                return;
            }
        }
        
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Start Player Round");
    }
}