using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FixedMovement : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform[] waypoints; // Array of waypoints
    [SerializeField] bool loop = true;


    // Check if agent is close to player
    // Check if agent is close to event

    private int currentWaypointIndex = 0; // The current waypoint index

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance) // Done with path
        {
            // Set the next waypoint (loop)
            SetNextWaypoint();
        }
    }

    void SetNextWaypoint()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogError("No waypoints set");
            return;
        }

        // Set the agent to go to the currently selected destination.
        

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        if (currentWaypointIndex < waypoints.Length)
        {
            agent.destination = waypoints[currentWaypointIndex].position;

            if (loop) currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            else currentWaypointIndex = (currentWaypointIndex + 1);
        }
        

    }
}
