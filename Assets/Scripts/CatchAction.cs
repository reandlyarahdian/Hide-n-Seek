using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Action/Catch")]
public class CatchAction : Act
{
    public override void Action(EnemyMovement movement)
    {
        movement.Target = null;
        movement.transform.Rotate(Vector3.forward, 180f);
        movement.agent.destination = movement.transform.position + Vector3.forward * 15f;
    }
}
