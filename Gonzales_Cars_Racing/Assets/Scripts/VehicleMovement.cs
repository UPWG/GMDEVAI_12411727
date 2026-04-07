using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    public float speed;
    public float minSpeed;
    public float maxSpeed;
    public float acceleration;
    public float deceleration;
    [SerializeField] float rotSpeed;
    public float breakAngle = 0;
    [SerializeField] Transform target;
    void Start()
    {
        //speed = 0;
        //minSpeed = 0;
        //maxSpeed = .5f;
        rotSpeed = 10;
        //acceleration = 1;
        //deceleration = 1;
        //breakAngle = 5;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 lookGoal = new Vector3(target.position.x, this.transform.position.y, target.position.z);

        Vector3 direction = lookGoal - this.transform.position;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);
        if (Vector3.Angle(target.forward, this.transform.forward) > breakAngle && speed > maxSpeed/2f)
        {
            speed = Mathf.Clamp(speed - (deceleration * Time.deltaTime), minSpeed, maxSpeed);
        }
        else 
        {
            speed = Mathf.Clamp(speed + (acceleration * Time.deltaTime), minSpeed, maxSpeed);
        }
            this.transform.Translate(0, 0, speed);
    }
}