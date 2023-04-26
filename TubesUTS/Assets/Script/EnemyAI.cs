using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameObject[] wayPoints;
    private int currentWayPointIndex = 0;

    [SerializeField] float viewRange;
    private NavMeshAgent agent;
    private int state;

    private void Start()
    {
        state = 0;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        switch(state)
        {
            case 0: Patrol(); break;
            case 1: ChasingPlayer(); break; 
        }
    }

    private void Patrol()
    {
        if (Vector3.Distance(transform.position, wayPoints[currentWayPointIndex].transform.position) < 1f)
        {
            currentWayPointIndex ++;
            if (currentWayPointIndex >= wayPoints.Length)
            {
                currentWayPointIndex = 0;
            }
        }
        agent.SetDestination(wayPoints[currentWayPointIndex].transform.position);

        if (Vector3.Distance(transform.position, player.transform.position) < viewRange) state = 1;
    }

    private void ChasingPlayer()
    {
        agent.SetDestination(player.transform.position);

        if (Vector3.Distance(transform.position, player.transform.position) > viewRange)
        {
            state = 0;
        }
    }
}
