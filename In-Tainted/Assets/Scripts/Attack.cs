using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : NPCBaseFSM
{
    float attackForce = 3;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        Debug.Log("IWorkingDone");
        monster.transform.Translate(Vector3.forward * attackForce * Time.deltaTime, Space.World);
        monster.GetComponent<AIControl>().atkCollider.enabled = true;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        Debug.Log("IWorkingDone");
        if (opponent != null)
        {
            if (stateInfo.normalizedTime >= 0.9f && stateInfo.normalizedTime < 1.0f)
            {
                animator.SetBool("isAttacking", false);
                animator.SetTrigger("Chase");
                monster.GetComponent<AIControl>().atkCollider.enabled = false;
            }
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
