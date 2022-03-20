using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Action/Stay")]
public class StayAction : Act
{
    [SerializeField]
    private float offsetX, offsetZ;

    public override void Action(EnemyMovement movement)
    {
        Stay(movement);
    }

    private void Stay(EnemyMovement movement)
    {
        if (movement.stack != null)
        {
            Vector3 vector = new Vector3(movement.stack.position.x + offsetX, movement.stack.position.y, movement.stack.position.z + offsetZ);
            movement.agent.SetDestination(vector);
        }
    }
}
