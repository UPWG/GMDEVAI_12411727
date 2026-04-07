using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollow : MonoBehaviour
{
    //[SerializeField] GameObject[] waypoints;
    [SerializeField] UnityStandardAssets.Utility.WaypointCircuit circuit;
    [SerializeField] int currWayPointIndex = 0;

    [SerializeField] float speed;
    [SerializeField] float rotSpeed;
    [SerializeField] float accuracy;
    void Start()
    {
        speed = 5;
        rotSpeed = 5;
        accuracy = 1;

        // = GameObject.FindGameObjectsWithTag("Waypoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (circuit.Waypoints.Length == 0) return;

        GameObject currentWayPoint = circuit.Waypoints[currWayPointIndex].gameObject;

        Vector3 lookGoal = new Vector3(currentWayPoint.transform.position.x, this.transform.position.y, currentWayPoint.transform.position.z);

        Vector3 direction = lookGoal - this.transform.position;

        if(direction.magnitude < 1.0f)
        {
            currWayPointIndex++;

            if (currWayPointIndex >= circuit.Waypoints.Length)
            {
                currWayPointIndex = 0;
            }
        }

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
