using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrullajeEnemigo : MonoBehaviour
{
    public float speed = 2f;           // Speed of the enemy
    public Transform pointA;           // Point A for patrolling
    public Transform pointB;           // Point B for patrolling

    private bool movingToB = true;     // Flag to determine which direction the enemy is moving

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (movingToB)
        {
            ChangeDirection(1);
            transform.position = Vector2.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, pointB.position) < 0.1f)
            {
                movingToB = false;
            }
        }
        else
        {
            ChangeDirection(-1);
            transform.position = Vector2.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, pointA.position) < 0.1f)
            {
                movingToB = true;
            }
        }
    }

    void ChangeDirection(int direction)
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = direction;
        transform.localScale = tempScale;
    }
}
