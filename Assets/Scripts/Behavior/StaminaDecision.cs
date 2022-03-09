using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decision/Stamina")]
public class StaminaDecision : Decide
{
    public override bool Decided(EnemyMovement movement)
    {
        return Stamina(movement);
    }

    private bool Stamina(EnemyMovement movement)
    {
        if(movement.Target.GetComponent<Stamina>().STR > movement.stamina.STR)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
