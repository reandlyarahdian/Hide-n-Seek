using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Action/Wander")]
public class WanderAction : Act
{
    public override void Action(EnemyMovement movement)
    {
        Wander(movement);
    }

    private void Wander(EnemyMovement movement)
    {
        movement.agent.SetDestination(movement.Wander(movement.agent, movement.col.radius));
    }
}
