using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BentengCatchedAction : Act
{
    public override void Action(EnemyMovement movement)
    {
        Catched(movement);
    }

    private void Catched(EnemyMovement movement)
    {
        movement.agent.isStopped = true;
        movement.transform.SetParent(movement.Target.transform);
    }
}
