using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEnd : PlayerBaseFSM
{
    private bool healed;
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        Debug.Log("IWorkingDone");
        if (stateInfo.normalizedTime >= 0.8f && stateInfo.normalizedTime < 1.0f)
        {
            if (!healed)
            {
                player.GetComponent<Health>().Heal();
                healed = true;
            }
            animator.SetBool("isHealing", false);
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.GetComponent<PlayerController>().healObject.SetActive(false);
        player.GetComponent<PlayerController>().weapon.SetActive(true);
        animator.SetBool("isHealing", false);
        player.GetComponent<PlayerController>().canMove = true;
    }
}
