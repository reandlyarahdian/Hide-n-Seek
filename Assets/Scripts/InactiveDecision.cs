using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decision/Inactive")]
public class InactiveDecision : Decide
{
    public override bool Decided(EnemyMovement movement)
    {
        if (movement.Target == null)
            return true;
        else return false;
    }
}
