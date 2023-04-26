using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameObject[] wayPoints;
    private int currentWayPointIndex = 0;

    [SerializeField] float initialSpeed;
    [SerializeField] float acceleration;
    [SerializeField] float viewRange;
    private float speed;
    private int state;
    private int incIndex;

    private void Start()
    {
        state = 0;
        speed = initialSpeed;
        incIndex = 1;
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
        if (Vector3.Distance(transform.position, wayPoints[currentWayPointIndex].transform.position) < .1f)
        {
            currentWayPointIndex += incIndex;
            if (currentWayPointIndex >= wayPoints.Length)
            {
                currentWayPointIndex = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[currentWayPointIndex].transform.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, player.transform.position) < viewRange) state = 1;
    }

    private void ChasingPlayer()
    {

        speed += acceleration;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, player.transform.position) > viewRange)
        {
            speed = initialSpeed;
            state = 0;
        }
    }
}
