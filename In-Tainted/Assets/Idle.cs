using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : NPCBaseFSM
{
    float idleTime = 4.0f;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        Debug.Log("IWorkingDone");
        animator.SetTrigger("Roam");
        idleTime = 4;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        Debug.Log("IWorkingDone");
        idleTime -= Time.deltaTime;
        if (opponent != null)
        {
            if (idleTime <= 0f)
            {
                animator.SetTrigger("Roam");
            }
            Vector3 dir = opponent.transform.position - monster.transform.position;
            float angle = Vector3.Angle(dir, monster.transform.forward); 

            if (dir.magnitude < visionDist && angle < visionAngle)
            {
                animator.SetTrigger("Chase");
            }
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
