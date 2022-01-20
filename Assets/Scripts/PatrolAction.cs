using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Action/Patrol")]
public class PatrolAction : Act
{
    public override void Action(EnemyMovement movement)
    {
        Patrol(movement);
    }

    private void Patrol(EnemyMovement movement)
    {
        movement.agent.destination = movement.wayPoints[movement.nextWayPoint].position;
        movement.agent.isStopped = false;

        if (movement.agent.remainingDistance <= movement.agent.stoppingDistance && !movement.agent.pathPending)
        {
            movement.nextWayPoint = (movement.nextWayPoint + 1) % movement.wayPoints.Count;
        }
    }
}
