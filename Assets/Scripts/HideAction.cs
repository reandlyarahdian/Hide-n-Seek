using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "AI/Action/Hide")]
public class HideAction : Act
{
    public override void Action(EnemyMovement movement)
    {
        Hide(movement);
    }

    private void Hide(EnemyMovement movement)
    {
        for (int i = 0; i < movement.colliders.Count; i++)
        {
            if (movement.Target != null)
            {
                if (NavMesh.SamplePosition(movement.colliders[i].transform.position, out NavMeshHit hit, 15f, movement.agent.areaMask))
                {
                    if (!NavMesh.FindClosestEdge(hit.position, out hit, movement.agent.areaMask))
                    {
                        movement.agent.isStopped = true;
                    }

                    if (Vector3.Dot(hit.normal, (movement.Target.position - hit.position).normalized) < 0)
                    {
                        movement.agent.SetDestination(hit.position);
                        movement.agent.isStopped = false;
                    }
                    else
                    {
                        if (NavMesh.SamplePosition(movement.colliders[i].transform.position - (movement.Target.position - hit.position).normalized * 2, out NavMeshHit hit2, 15f, movement.agent.areaMask))
                        {
                            if (!NavMesh.FindClosestEdge(hit2.position, out hit2, movement.agent.areaMask))
                            {
                                movement.agent.isStopped = true;
                            }

                            if (Vector3.Dot(hit2.normal, (movement.Target.position - hit2.position).normalized) < 0)
                            {
                                movement.agent.SetDestination(hit2.position);
                                movement.agent.isStopped = false;
                            }
                        }
                    }
                }
                else
                {
                    movement.agent.isStopped = true;
                }
            }
            else
            {
                movement.agent.SetDestination(movement.Wander(movement.agent, movement.col.radius));
            }
        }
    }
}
