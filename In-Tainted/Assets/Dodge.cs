using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Dodge : PlayerBaseFSM
{
    private bool isDodging = false;
    private Vector3 dodgeDirection;
    private float dodgeForce = 10f;
    private float lastDodgeTime;
    public float dodgeCooldown = 1f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
{
    base.OnStateEnter(animator, stateInfo, layerIndex);

        Debug.Log("Working");
        player.GetComponent<PlayerController>().canMove = false;
        animator.SetBool("isDodging", true);
        lastDodgeTime = Time.time;
        isDodging = true;

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
            dodgeDirection = player.transform.forward;
        else
            dodgeDirection = move.normalized;

        player.transform.rotation = Quaternion.LookRotation(dodgeDirection);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if (stateInfo.normalizedTime >= 1f && !animator.IsInTransition(layerIndex))
        {
            if (player != null)
            {
                player.GetComponent<PlayerController>().canMove = true;
                animator.SetBool("isDodging", false);
                Debug.Log("WorkingDone");
            }
            if (isDodging)
            {
                player.transform.Translate(dodgeDirection * dodgeForce * Time.deltaTime, Space.World);
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);

       
    }
}
