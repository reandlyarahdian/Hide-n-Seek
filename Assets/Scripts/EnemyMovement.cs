using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private State curentS, remainS;
    
    public List<Transform> wayPoints;
    public LayerMask mask;

    [HideInInspector]
    public NavMeshAgent agent;
    [HideInInspector]
    public Light light;
    [HideInInspector]
    public Transform Target;
    [HideInInspector]
    public Transform Hide;
    [HideInInspector]
    public SphereCollider col;
    [HideInInspector]
    public List<Collider> colliders;
    [HideInInspector]
    public int nextWayPoint;
    public int id;

    private bool AIActive;
    private float TimeElapsed;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        light = GetComponentInChildren<Light>();
        col = GetComponentInChildren<SphereCollider>();
    }

    public void Setup(bool active, List<Transform> waypoints)
    {
        wayPoints = waypoints;
        AIActive = active;
        if (AIActive) agent.enabled = true;
        else agent.enabled = false;
    }

    private void Update()
    {
        curentS.UpdateState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        colliders.Add(other);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Hide")) Target = other.transform;
        if (other.CompareTag("Seek")) Hide = other.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        Target = null;
        colliders.Remove(other);
    }

    public void TransitionToState(State nextS)
    {
        if(nextS != remainS)
        {
            curentS = nextS;
            TimeElapsed = 0;
        }
    }

    public bool CheckCountDown(float duration)
    {
        TimeElapsed += Time.deltaTime;
        return (TimeElapsed >= duration);
    }

    public Vector3 Wander(NavMeshAgent agent, float radius)
    {
        var randDirection = Random.insideUnitSphere * radius;
        randDirection += agent.transform.position;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, radius, -1);
        return navHit.position;
    }
}
