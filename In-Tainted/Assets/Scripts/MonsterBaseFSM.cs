using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBaseFSM : StateMachineBehaviour
{
    public GameObject monster;
    public GameObject opponent;
    public float speed = 2.0f;
    public float accuracy = 3.0f;
    public float visionDist = 20.0f; 
    public float visionAngle = 45.0f;
    public float attackRange = 6f;
    public float rotationSpeed = 5.0f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        monster = animator.gameObject;
        opponent = GameObject.FindGameObjectWithTag("Player");
    }
}
