using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum State
{
    Idle,
    Running,
    Casting
}

public class AIControl : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    public NavMeshAgent agent;
    public Collider atkCollider;


    float rotationSpeed = 2.0f;
    float speed = 2.0f;
    float visionDist = 20.0f;
    float visionAngle = 30.0f;
    float castRange = 5.0f;

    State state;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = this.GetComponent<Animator>();
        agent = this.GetComponent<NavMeshAgent>();

    }
    void LateUpdate()
    {

    }
    public GameObject GetPlayer()
    {
        return player;
    }
}
