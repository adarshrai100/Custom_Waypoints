using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class WaypointNavigator : MonoBehaviour
{
    NavMeshAgent controller;
    public Waypoint currentWaypoint;

    private void Awake()
    {
        controller = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        controller.SetDestination(currentWaypoint.GetPosition());
    }

    private void FixedUpdate()
    {
        if (!controller.pathPending)
        {
            if (controller.remainingDistance <= controller.stoppingDistance)
            {
                if (!controller.hasPath || controller.velocity.sqrMagnitude == 0f)
                {
                    // Done
                    currentWaypoint = currentWaypoint.nextWaypoint;
                    controller.SetDestination(currentWaypoint.GetPosition());
                }
            }
        }
    }
}
