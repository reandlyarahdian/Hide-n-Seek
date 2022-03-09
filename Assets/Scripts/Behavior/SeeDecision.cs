using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decision/See")]
public class SeeDecision : Decide
{
    public override bool Decided(EnemyMovement movement)
    {
        return see(movement);
    }

    private bool see(EnemyMovement movement)
    {
        if (movement.Target != null)
        {
            if (Vector3.Distance(movement.Target.transform.position, movement.transform.position) < movement.light.range)
            {
                Vector3 dir = (movement.Target.transform.position - movement.transform.position);
                float dot = Vector3.Angle(movement.transform.forward, dir);
                if (dot < movement.light.spotAngle /2)
                {
                    if (Physics.Raycast(movement.transform.position, dir, out RaycastHit hit, movement.light.range))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
