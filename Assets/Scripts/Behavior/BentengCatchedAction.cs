using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Action/BaseCatched")]
public class BentengCatchedAction : Act
{
    public string BaseTag;
    public override void Action(EnemyMovement movement)
    {
        Catched(movement);
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

    private void Catched(EnemyMovement movement)
    {
        movement.transform.SetParent(movement.Target.transform);
        movement.agent.SetDestination(new Vector3(TagCheck(BaseTag) / 9f, 0, TagCheck(BaseTag)));
    }
}
