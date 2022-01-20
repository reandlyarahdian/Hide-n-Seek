using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decision/Hear")]
public class HearDecision : Decide
{
    public override bool Decided(EnemyMovement movement)
    {
        return see(movement);
    }

    private bool see(EnemyMovement movement)
    {
        if (movement.Hide != null)
        {
            if (Vector3.Distance(movement.Hide.transform.position, movement.transform.position) < movement.col.radius)
            {
                Vector3 dir = (movement.Hide.transform.position - movement.transform.position).normalized;
                float dot = Vector3.Angle(movement.transform.forward, dir);
                if (dot >= Mathf.Cos(360f))
                {
                    if (Physics.Raycast(movement.transform.position, dir, out RaycastHit hit, movement.col.radius))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
