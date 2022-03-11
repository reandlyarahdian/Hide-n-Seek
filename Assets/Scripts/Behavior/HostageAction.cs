using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Action/HostageACtion")]
public class HostageAction : Act
{
    public string Taging;

    public override void Action(EnemyMovement movement)
    {
        throw new System.NotImplementedException();
    }

    private void Hostage(EnemyMovement movement)
    {
        foreach(var col in movement.colliders)
        {
            if(col.tag == Taging)
            {
                movement.agent.isStopped = true;
                movement.transform.SetParent(col.transform);
            }
        }
    }
}
