using System.Collections;
using UnityEngine;

public class EnemyMovement : Movement
{
    private float stopDistance = 1f; // Distance from player to stop before reaching them

    protected override void Start()
    {
        moveSpeed = 2f; // Set move speed for the enemy
        base.Start();
    }

    protected override void MoveToPosition(Vector3 newPosition)
    {
        // Calculate direction vector towards player
        Vector3 directionToPlayer = (newPosition - transform.position).normalized;

        targetPosition = newPosition - directionToPlayer * stopDistance;

        transform.LookAt(newPosition);

        isMoving = true;
    }

    protected override void OnPositionSelected(Vector3 position)
    {
        // Additional behavior specific to enemy when a position is selected can be added here
        if (Vector3.Distance(transform.position, targetPosition) <= stopDistance)
        {
            isMoving = false; 
            StartCoroutine(WaitForPlayerMove());
        }
    }

    private IEnumerator WaitForPlayerMove()
    {
        yield return new WaitUntil(() => !isMoving);
    }
}
