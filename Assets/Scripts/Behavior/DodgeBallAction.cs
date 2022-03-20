using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Action/DodgeBall")]
public class DodgeBallAction : Act
{
    public override void Action(EnemyMovement movement)
    {
        Dodge(movement);
    }

    private void Dodge(EnemyMovement movement)
    {
        Vector3 vector = new Vector3(1, 0, 1);
        movement.agent.SetDestination(movement.transform.position + vector);
    }
}
