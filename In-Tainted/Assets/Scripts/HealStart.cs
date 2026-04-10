using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealStart : PlayerBaseFSM
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        Debug.Log("Working");
        animator.SetBool("isHealing", true);
        player.GetComponent<PlayerController>().weapon.SetActive(false);
        player.GetComponent<PlayerController>().healObject.SetActive(true);
        player.GetComponent<PlayerController>().canMove = false;
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        Debug.Log("IWorkingDone");
        player.GetComponent<PlayerController>().healObject.SetActive(false);
        player.GetComponent<PlayerController>().weapon.SetActive(true);
        animator.SetBool("isHealing", false);
        player.GetComponent<PlayerController>().canMove = true;
    }
}
