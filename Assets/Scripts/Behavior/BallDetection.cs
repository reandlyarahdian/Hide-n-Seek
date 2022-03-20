using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decision/BallDetection")]
public class BallDetection : Decide
{
    [SerializeField]
    private float radius;

    public override bool Decided(EnemyMovement movement)
    {
        return Detection(movement);
    }

    private bool Detection(EnemyMovement movement)
    {
        if(movement.ball != null)
        {
            if (Vector3.Distance(movement.ball.transform.position, movement.transform.position) < radius)
            {
                Vector3 dir = (movement.ball.transform.position - movement.transform.position).normalized;
                float dot = Vector3.Angle(movement.transform.forward, dir);
                if (dot < 360 / 2)
                {
                    if (Physics.Raycast(movement.transform.position, dir, out RaycastHit hit, radius))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
