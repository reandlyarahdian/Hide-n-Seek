using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decision/Base")]
public class BaseDecision : Decide
{
    public string taging;

    public override bool Decided(EnemyMovement movement)
    {
        return Base(movement);
    }

    private bool Base(EnemyMovement movement)
    {
        foreach(var col in movement.colliders)
        {
            if (col.tag == taging)
            {
                if (Vector3.Distance(col.transform.position, movement.transform.position) < movement.col.radius / 2)
                {
                    Vector3 dir = (col.transform.position - movement.transform.position).normalized;
                    float dot = Vector3.Angle(movement.transform.forward, dir);
                    if (dot < 360 / 2)
                    {
                        if (Physics.Raycast(movement.transform.position, dir, out RaycastHit hit, movement.col.radius))
                        {
                            return true;
                        }
                    }
                }
            }
        }

        return false;
    }
}
