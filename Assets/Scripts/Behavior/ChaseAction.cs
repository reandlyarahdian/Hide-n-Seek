using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Action/Chase")]
public class ChaseAction : Act
{
    public override void Action(EnemyMovement movement)
    {
        Chase(movement);
    }

    private void Chase(EnemyMovement movement)
    {
        if (movement.Target != null) movement.agent.destination = movement.Target.position;
        else movement.agent.destination = Vector3.forward;
        movement.agent.isStopped = false;
    }
}
