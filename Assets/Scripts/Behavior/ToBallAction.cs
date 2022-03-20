using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Action/ToBall")]
public class ToBallAction : Act
{
    public override void Action(EnemyMovement movement)
    {
        ToBall(movement);
    }

    private void ToBall(EnemyMovement movement)
    {
        movement.agent.SetDestination(movement.ball.position);
    }
}
