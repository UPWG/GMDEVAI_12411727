using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovementAI : MonoBehaviour
{
    [SerializeField] Vector3 direction;
    [SerializeField] float speed;
    [SerializeField] float currentSpeed; 
    [SerializeField] float rotSpeed;
    [SerializeField] Transform target;

    void Start()
    {
        speed = 5f;
        currentSpeed = 0f;
        rotSpeed = 4f;
    }

    void LateUpdate()
    {
        Vector3 player = target.position;

        direction = (player - transform.position).normalized;

        if (direction != Vector3.zero)
        {
            Quaternion targetRot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRot,
                Time.deltaTime * rotSpeed
            );
        }

        float targetSpeed = Vector3.Distance(player, transform.position) > 3f ? speed : 0f;
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, Time.deltaTime * 3f);

        if (currentSpeed > 0f)
        {
            transform.Translate(0, 0, currentSpeed * Time.deltaTime);
        }
    }
}