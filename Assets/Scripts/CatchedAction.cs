using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Action/Stoped")]
public class CatchedAction : Act
{
    public override void Action(EnemyMovement movement)
    {
        movement.agent.isStopped = true;
    }
}
