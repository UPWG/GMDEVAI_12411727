using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerBaseFSM
{
    private bool isAttacking = false;
    private Vector3 attackDirection;
    private float lastAttackTime;
    public float attackCooldown = 1f;
    public float attackForce = 5;
    private float lastAttackEndTime;
    private bool attackEnded;



    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        Debug.Log("Working");
        if (player.GetComponent<PlayerController>().atkIndex <= 3)
        {
            player.GetComponent<PlayerController>().atkIndex++;
            animator.SetInteger("AttackIndex", player.GetComponent<PlayerController>().atkIndex);
        }
        else if(player.GetComponent<PlayerController>().atkIndex >= 4)
        {
            player.GetComponent<PlayerController>().atkIndex = 1;
        }
        player.GetComponent<PlayerController>().canMove = false;
        animator.SetBool("isAttacking", true);
        lastAttackTime = Time.time;
        isAttacking = true;

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 forward = player.GetComponent<PlayerController>().cameraTransform.forward;
        Vector3 right = player.GetComponent<PlayerController>().cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 move = forward * moveZ + right * moveX;

        if (move.sqrMagnitude < 0.001f)
            attackDirection = player.transform.forward;
        else
            attackDirection = move.normalized;

        player.transform.rotation = Quaternion.LookRotation(attackDirection);
        player.GetComponent<PlayerController>().OnAttackEnd();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if (stateInfo.normalizedTime >= 0.25f && stateInfo.normalizedTime < 1.0f)
        {
            if (player != null)
            {
                player.GetComponent<PlayerController>().isAttacking = false;
                Debug.Log("WorkingDone");
            }
        }
        if (stateInfo.normalizedTime >= 0.7f && stateInfo.normalizedTime < 1.0f)
        {
            animator.SetBool("isAttacking", false);
            player.GetComponent<PlayerController>().canMove = true;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        Debug.Log("IWorkingDone");

    }
}
