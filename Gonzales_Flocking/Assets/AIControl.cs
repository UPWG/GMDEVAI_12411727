using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AIControl : MonoBehaviour
{
    GameObject[] goalLocations;
    NavMeshAgent agent;
    Animator anim;
    float speedMultiplier;
    float detectionRadius = 10;
    float fleeRadius = 15;



    void ResetAgent()
    {
        speedMultiplier = Random.Range(0.5f, 1.5f);
        agent.speed = 2 * speedMultiplier;
        agent.angularSpeed = 120;
        anim.SetFloat("speedMultiplier", speedMultiplier);
        anim.SetTrigger("isWalking");
        agent.ResetPath();
    }
    void Start()
    {
        goalLocations = GameObject.FindGameObjectsWithTag("goal");
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();

        agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);

        anim.SetFloat("wOffset", Random.Range(0, 1f));

        ResetAgent();

    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 1)
        {
            ResetAgent();
            agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
        }
    }
    public void DetectMonsterObstacle(Vector3 location)
    {
        if (Vector3.Distance(location, this.transform.position) < detectionRadius)
        {
            Vector3 fleeDirection = (this.transform.position - location).normalized;
            Vector3 newGoal = this.transform.position + fleeDirection * fleeRadius;

            NavMeshPath path = new NavMeshPath()
                ;
            agent.CalculatePath(newGoal, path);

            if (path.status != NavMeshPathStatus.PathInvalid)
            {
                agent.SetDestination(path.corners[path.corners.Length - 1]);
                anim.SetTrigger("isRunning");
                agent.speed = 6;
                agent.angularSpeed = 500;

            }
        }
        
    }
    public void DetectFlockObstacle(Vector3 location)
    {
        if (Vector3.Distance(location, this.transform.position) < detectionRadius)
        {
            agent.SetDestination(location);
            anim.SetTrigger("isRunning");
            agent.speed = 5;
            agent.angularSpeed = 500;
        }
    }
}
