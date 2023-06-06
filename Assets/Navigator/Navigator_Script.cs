using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigator_Script : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform moveTo;
    [SerializeField] Transform player;

    void OnEnable()
    {
        agent.Warp(new Vector3(player.localPosition.x, 0.8f, player.localPosition.z));
        agent.SetDestination(moveTo.position);
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(new Vector3(moveTo.position.x, 0.8f, moveTo.position.z));

        float dist = agent.remainingDistance;
        if (dist != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0)
        {
            agent.Warp(new Vector3(player.localPosition.x, 0.8f, player.localPosition.z));
            agent.SetDestination(new Vector3(moveTo.position.x, 0.8f, moveTo.position.z));
        }
    }
}
