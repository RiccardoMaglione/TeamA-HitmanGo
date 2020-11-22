using DG.Tweening;
using HGO.core;
using UnityEngine;

/// <summary>
/// Gestore della fase di morte del giocatore
/// </summary>
public static class DeathManager
{
    static Vector3 enemyDirection;
    static GameObject m_player;
    static float death_time = 0.2f;
    public static void RegisterEnemyDirection(Vector3 dir)
    {
        enemyDirection = dir;
    }
    public static void KillPlayer(ref PlayerController controller)
    {
        m_player = controller.gameObject;
        Debug.LogError(enemyDirection * 90f);
        m_player.transform.DORotate(enemyDirection * 90f, death_time);
    }
}

public class PlayPlayerDeathAnimation : StateMachineBehaviour
{
    PlayerController pc;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!pc) pc = FindObjectOfType<PlayerController>();

        DeathManager.KillPlayer(ref pc);
        //animator.SetTrigger("Reset Level");
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       // pc.gameObject.transform.DORotate(new Vector3(0, 0, 90), 0.2f);
       //if(pc.gameObject.transform.rotation == Quaternion.Euler(0,0,90)) animator.SetTrigger("Reset Level");
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //pc.gameObject.transform.DOKill();
        animator.ResetTrigger("Play Player Death Animation");
    }
}

