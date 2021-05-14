using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{

    private NavMeshAgent companionAgent;

    public GameObject playerobj;

    public float companionDistance;

    private void Start()
    {
        companionAgent = GetComponent<NavMeshAgent>();

    }

    private void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, playerobj.transform.position);

        if(distance < companionDistance)
        {
            Vector3 dirToPlayer = transform.position - playerobj.transform.position;

            Vector3 newPos = transform.position - dirToPlayer;

            companionAgent.SetDestination(newPos);
        }
    }
}
