using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPath1 : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject wpManager;
    GameObject[] wps;
    
    
    void Start()
    {
        wps = wpManager.GetComponent<WaypointManager>().waypoints;
        agent = this.GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    
    public void GoToHelipad()
    {
        //graph.AStar(currentNode, wps[0]);
        //currentWaypointIndex = 0;
        agent.SetDestination(wps[0].transform.position);
    }
    public void GoToTwinMountains()
    {
        //graph.AStar(currentNode, wps[3]);
        //currentWaypointIndex = 0;
        agent.SetDestination(wps[3].transform.position);
    }
    public void GoToBarracks()
    {
        //graph.AStar(currentNode, wps[4]);
        //currentWaypointIndex = 0;
        agent.SetDestination(wps[4].transform.position);
    }
    public void GoToCommandCenter()
    {
        //graph.AStar(currentNode, wps[19]);
        //currentWaypointIndex = 0;
        agent.SetDestination(wps[19].transform.position);
    }
    public void GoToOilRefineries()
    {
        //graph.AStar(currentNode, wps[15]);
        //currentWaypointIndex = 0;
        agent.SetDestination(wps[15].transform.position);
    }
    public void GoToTankers()
    {
        //graph.AStar(currentNode, wps[9]);
        //currentWaypointIndex = 0;
        agent.SetDestination(wps[9].transform.position);
    }
    public void GoToRadar()
    {
        //graph.AStar(currentNode, wps[6]);
        //currentWaypointIndex = 0;
        agent.SetDestination(wps[6].transform.position);
    }
    public void GoToCommandPost()
    {
        //graph.AStar(currentNode, wps[7]);
        //currentWaypointIndex = 0;
        agent.SetDestination(wps[7].transform.position);
    }
    public void GoToCenter()
    {
        //graph.AStar(currentNode, wps[21]);
        //currentWaypointIndex = 0;
        agent.SetDestination(wps[21].transform.position);
    }
}
