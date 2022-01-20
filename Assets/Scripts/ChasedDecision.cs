using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decision/Chased")]
public class ChasedDecision : Decide
{
    public override bool Decided(EnemyMovement movement)
    {
        return see(movement);
    }

    private bool see(EnemyMovement movement)
    {
        if (movement.Target != null)
        {
            if (Vector3.Distance(movement.Target.transform.position, movement.transform.position) < 3.5f)
            {
                if (Physics.Raycast(movement.transform.position, Vector3.back, out RaycastHit hit, 3.5f))
                {
                    return true;
                }
                else if (Physics.Raycast(movement.transform.position, Vector3.forward, out RaycastHit hit1, 3.5f))
                {
                    return true;
                }
                else if (Physics.Raycast(movement.transform.position, Vector3.right, out RaycastHit hit2, 3.5f))
                {
                    return true;
                }
                else if (Physics.Raycast(movement.transform.position, Vector3.left, out RaycastHit hit3, 3.5f))
                {
                    return true;
                }
            }
        }
        return false;
    }
}
