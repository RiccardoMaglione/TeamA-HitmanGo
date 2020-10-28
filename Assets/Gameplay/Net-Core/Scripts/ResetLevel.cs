using HGO.core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel : StateMachineBehaviour
{
    LevelManager lm = null;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!lm) lm = FindObjectOfType<LevelManager>();

        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

        animator.SetTrigger("Start Player Round");
        return;
    }
}