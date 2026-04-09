using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Flee : NPCBaseFSM
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        var direction = NPC.transform.position - opponent.transform.position;
        NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation,Quaternion.LookRotation(direction), 1.0f * Time.deltaTime);     
        NPC.transform.Translate(0, 0, Time.deltaTime * speed);
    }
}
