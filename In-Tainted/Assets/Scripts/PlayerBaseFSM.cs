using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseFSM : StateMachineBehaviour
{
    public GameObject player;
    //public GameObject opponent;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.gameObject;
    }
}
