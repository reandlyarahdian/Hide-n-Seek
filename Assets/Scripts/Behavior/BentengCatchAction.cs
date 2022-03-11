using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Action/BaseCatch")]
public class BentengCatchAction : Act
{
    public string BaseTag;

    public override void Action(EnemyMovement movement)
    {
        MoveToBase(movement);
    }

    private float TagCheck(string taging)
    {
        switch (taging)
        {
            case "A":
                return 45f;
            case "B":
                return -45f;
            default:
                return 0f;
        }
    }

    private void MoveToBase(EnemyMovement movement)
    {
        foreach (var col in movement.colliders)
        {
            if (col.gameObject.tag == BaseTag)
            {
                movement.agent.SetDestination(col.transform.position);
            }
            else
            {
                movement.agent.SetDestination(new Vector3(TagCheck(BaseTag) / 9f, 0, TagCheck(BaseTag)));
            }
        }
    }
}
