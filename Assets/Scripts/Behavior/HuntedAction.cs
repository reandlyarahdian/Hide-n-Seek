using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Action/Hunted")]
public class HuntedAction : Act
{
    public Material mat;

    public override void Action(EnemyMovement movement)
    {
        Hunted(movement);
    }

    private void Hunted(EnemyMovement movement)
    {
        movement.hiding.Hunted(mat);
        movement.light.range = 0;
        movement.gameObject.tag = "Hide";
    }
}
