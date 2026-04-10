using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : NPCBaseFSM
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        Debug.Log("IWorkingDone");

    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        Debug.Log("IWorkingDone");
        if (opponent != null)
        {
            Vector3 dir = opponent.transform.position - monster.transform.position;
            float angle = Vector3.Angle(dir, monster.transform.forward);

            if (dir.magnitude < visionDist && angle < visionAngle)
            {
                dir.y = 0;

                monster.transform.rotation = Quaternion.Slerp(monster.transform.rotation,
                                            Quaternion.LookRotation(dir),
                                            Time.deltaTime * rotationSpeed);
                monster.GetComponent<AIControl>().agent.SetDestination(opponent.transform.position);
            }
            if (dir.magnitude < attackRange)
            {
                animator.SetTrigger("Attack");
            }
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
