using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decision/Scan")]
public class ScanDecision : Decide
{
    public override bool Decided(EnemyMovement movement)
    {
        return Scan(movement);
    }

    private bool Scan(EnemyMovement movement)
    {
        movement.agent.isStopped = true;
        movement.transform.Rotate(0, 5f * Time.deltaTime, 0);
        return movement.CheckCountDown(5f);
    }
}
