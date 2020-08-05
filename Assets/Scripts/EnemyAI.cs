using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 10f;


    NavMeshAgent navMeshAgent;
    float distToTarg = Mathf.Infinity;
    bool isProvoked = false;
    bool inRange = false;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distToTarg = Vector3.Distance(target.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distToTarg <= chaseRange)
        {
            isProvoked = true;
            ChaseTarget();
        }
    }

    private void EngageTarget()
    {
        if (distToTarg >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (distToTarg <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void AttackTarget()
    {
        Debug.Log(name + " Attacking!" + target.name);
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.75F);
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
