using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]

public class FollowTarget : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent navAgent;
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        //navAgent.SetDestination(target.transform.position);

    }

    void Update()
    {
       
        navAgent.SetDestination(target.transform.position);
        navAgent.speed = 1.5f;
        navAgent.autoBraking = true;
        navAgent.stoppingDistance = 1;
        navAgent.height = 0.8f;
        navAgent.radius = 0.3f;
    }
}
