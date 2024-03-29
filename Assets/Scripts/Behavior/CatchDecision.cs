using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decision/Catch")]
public class CatchDecision : Decide
{
    public override bool Decided(EnemyMovement movement)
    {
        return see(movement);
    }

    private bool see(EnemyMovement movement)
    {
        if (movement.Target != null)
        {
            if (Vector3.Distance(movement.Target.transform.position, movement.transform.position) < movement.light.range / 2f)
            {
                Vector3 dir = (movement.Target.transform.position - movement.transform.position).normalized;
                float dot = Vector3.Angle(movement.transform.forward, dir);
                if (dot >= Mathf.Cos(movement.light.range))
                {
                    if (Physics.Raycast(movement.transform.position, dir, out RaycastHit hit, movement.light.range / 2f))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
