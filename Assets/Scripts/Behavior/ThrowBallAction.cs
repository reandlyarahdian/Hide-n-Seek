using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Action/ThrowBall")]
public class ThrowBallAction : Act
{
    public override void Action(EnemyMovement movement)
    {
        Throw(movement);
    }

    private void Throw(EnemyMovement movement)
    {
        if(movement.ball != null)
        {
            movement.ball.GetComponent<Ball>().MoveBall(movement.Target.position);
        }
    }
}
