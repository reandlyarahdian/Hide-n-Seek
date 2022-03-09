using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Action/BaseAct")]
public class BaseAction : Act
{
    public string BaseTag;

    public override void Action(EnemyMovement movement)
    {
        float enemyBase = TagCheck(BaseTag);
        MoveToBase(movement, enemyBase);
    }

    private float TagCheck(string taging)
    {
        switch (taging)
        {
            case "A":
                return -45f;
            case "B":
                return 45f;
            default:
                return 0f;
        }
    }

    private void MoveToBase(EnemyMovement movement, float enemyBase)
    {
        foreach(var col in movement.colliders)
        {
            if(col.gameObject.tag == BaseTag)
            {
                movement.agent.SetDestination(col.transform.position);
            }
            else
            {
                movement.agent.SetDestination(new Vector3(0, 0, TagCheck(BaseTag)));
            }
        }
    }
}
