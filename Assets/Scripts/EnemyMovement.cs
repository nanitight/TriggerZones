using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int currentWayPoint = 0;
    [SerializeField] float movementSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        //if enemy is close to constraint, change the constraint it is moving towards
        if (Vector3.Distance(transform.position, waypoints[currentWayPoint].transform.position) < 0.1f)
        {
            currentWayPoint++; 
            if (currentWayPoint >= waypoints.Length)
            {
                currentWayPoint = 0;
            }
        }

        //move the enemy to current selected constraint
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWayPoint].transform.position, movementSpeed*Time.deltaTime);

    }
}
