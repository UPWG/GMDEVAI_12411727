using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    GameObject[] agents;
    [SerializeField] Transform target;
    // Start is called before the first frame update
    void Start()
    {
        agents = GameObject.FindGameObjectsWithTag("AI");
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    RaycastHit hit;

        //    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000))
        //    {
        //        foreach (GameObject ai in agents)
        //        {
        //            ai.GetComponent<AIContol>().agent.SetDestination(hit.point);
        //        }
        //    }
        //}
        foreach (GameObject ai in agents)
        {
            if (Vector3.Distance(target.position, ai.transform.position) > 2)
            {
                ai.GetComponent<AIContol>().agent.SetDestination(target.position);
            }
        }
    }
}
