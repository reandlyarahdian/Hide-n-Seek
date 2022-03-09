using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Action/Hunting")]
public class HuntingAction : Act
{
    public Material mat;

    public override void Action(EnemyMovement movement)
    {
        Hunting(movement);
    }

    private void Hunting(EnemyMovement movement)
    {
        movement.hiding.Hunted(mat);
        movement.light.range = 7f;
        movement.gameObject.tag = "Seek";
    }
}
