using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Roam : NPCBaseFSM
{
    GameObject[] waypoints;
    int currentWaypoint;
    float speedMultiplier;
    private void Awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }
    void ResetAgent()
    {
        monster.GetComponent<AIControl>().agent.angularSpeed = 120;
        monster.GetComponent<AIControl>().agent.ResetPath();
    }
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        Debug.Log("IWorkingDone");
        currentWaypoint = 0;
        monster.GetComponent<AIControl>().agent.SetDestination(waypoints[Random.Range(0, waypoints.Length)].transform.position);

    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        Debug.Log("IWorkingDone");
        if (opponent != null)
        {
            if (waypoints.Length == 0) return;
            
            if (monster.GetComponent<AIControl>().agent.remainingDistance < 2)
            {
                if (Random.Range(1, 2) == 1)
                {
                    animator.SetTrigger("Idle");
                }
                ResetAgent();
                monster.GetComponent<AIControl>().agent.SetDestination(waypoints[Random.Range(0, waypoints.Length)].transform.position);
            }
            animator.SetFloat("dist", Vector3.Distance(animator.gameObject.transform.position, opponent.transform.position));
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
