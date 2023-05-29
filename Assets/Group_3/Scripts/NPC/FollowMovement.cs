using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowMovement : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform player; 
    [SerializeField] float stoppingRadius = 5f;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        agent.destination = (distanceToPlayer > stoppingRadius) ? player.position: transform.position;
        agent.isStopped = (distanceToPlayer <= stoppingRadius);
    }
}
