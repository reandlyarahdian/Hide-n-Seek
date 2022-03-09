using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decision/Chased")]
public class ChasedDecision : Decide
{
    public LayerMask mask;
    public float radius;

    public override bool Decided(EnemyMovement movement)
    {
        return see(movement);
    }

    private bool see(EnemyMovement movement)
    {
        if (movement.Hide != null)
        {
            if (Vector3.Distance(movement.Hide.transform.position, movement.transform.position) < radius)
            {
                foreach(Collider col in Physics.OverlapSphere(movement.transform.position, radius, mask, QueryTriggerInteraction.Collide))
                {
                    if(col.gameObject == movement.Hide.gameObject)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
