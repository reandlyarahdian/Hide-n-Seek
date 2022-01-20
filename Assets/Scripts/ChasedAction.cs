using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Action/Chased")]
public class ChasedAction : Act
{
    public override void Action(EnemyMovement movement)
    {
        movement.agent.isStopped = true;
        GameManager.Instance.PointAdder(1, 100);
        movement.gameObject.SetActive(false);
    }
}
