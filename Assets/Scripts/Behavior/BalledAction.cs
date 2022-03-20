using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Action/Balled")]
public class BalledAction : Act
{
    public override void Action(EnemyMovement movement)
    {
        Balled(movement);
    }

    private void Balled(EnemyMovement movement)
    {
        movement.gameObject.SetActive(false);
    }
}
