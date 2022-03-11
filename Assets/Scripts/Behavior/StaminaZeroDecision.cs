using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decision/Zero")]
public class StaminaZeroDecision : Decide
{
    public override bool Decided(EnemyMovement movement)
    {
        return Zero(movement);
    }

    private bool Zero(EnemyMovement movement)
    {
        if (movement.stamina.STR == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
