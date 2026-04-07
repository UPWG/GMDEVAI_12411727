using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotSpeed;
    [SerializeField] Vector3 direction;

    void Start()
    {
       
        direction.y = 0f;
        speed = 5f;
        rotSpeed = 5;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        direction = new Vector3(moveX, 0f, moveZ);

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotSpeed* Time.deltaTime
            );
        }

        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
    }
}
