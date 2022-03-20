using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decision/BallInHand")]
public class BallInHand : Decide
{
    public override bool Decided(EnemyMovement movement)
    {
        return InHand(movement);
    }

    private bool InHand(EnemyMovement movement)
    {
        if(movement.ball != null)
        {
            if (!movement.ball.GetComponent<Ball>().inPlayer)
            {
                return true;
            }
        }

        return false;
    }
}
