using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class See : MonoBehaviour
{
    [SerializeField]
    private float sightRadius = 15f;
    private UnityEvent unityEvent;
    private Collider[] colliders;

    private void Update()
    {
        CheckPlayer(unityEvent, 360f, 3f, sightRadius);
    }

    private void CheckPlayer(UnityEvent @event, float angleSight, float viewDistance, float distance)
    {
        colliders = Physics.OverlapSphere(transform.position, distance);

        foreach (Collider col in colliders)
        {
            if (col.gameObject.CompareTag("Seek") && this.gameObject.CompareTag("Hide") && SeePlayer(col.transform, angleSight, viewDistance))
            {
                GameManager.Instance.PointAdder(1, 100);
                this.gameObject.SetActive(false);
            }
        }
    }

    private bool SeePlayer(Transform Target, float angleSight, float viewDistance)
    {
        if (Vector3.Distance(Target.transform.position, transform.position) < viewDistance)
        {
            Vector3 dir = (Target.transform.position - transform.position).normalized;
            float dot = Vector3.Angle(transform.forward, dir);
            if (dot < angleSight/ 2)
            {
                if (Physics.Raycast(transform.position, dir, out RaycastHit hit, viewDistance))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 12f);
    }
}
