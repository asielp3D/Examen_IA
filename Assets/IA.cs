using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA : MonoBehaviour
{
    enum State
    {
        Patrolling,

        Chasing,

        Attacking
    }

    [SerializeField] State currentState;

    private NavMeshAgent agent;

    private Transform player;

    [SerializeField] private Transform[] patrolPoints;

    [SerializeField] private float detectionRange = 10f;

    [SerializeField] private float attackRange = 3f;
    
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        SetRandomPoint(); 
        currentState = State.Patrolling;
    }

    // Update is called once per frame
    void Update()
    {
       
        switch(currentState) 
        {
            case State.Patrolling:
                Patrol();
            break;

            case State.Chasing:
                Chase();
            break;

            case State.Attacking:
                Attack();
            break;
        }
    }

    void SetRandomPoint()
    {
        agent.destination = patrolPoints[Random.Range(0, patrolPoints.Length - 1)].position;
    }

    bool IsInRange(float range)
    {
        if(Vector3.Distance(transform.position, player.position) < range) 
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    void Patrol()
    {
         if(IsInRange(detectionRange) == true) 
        {
            currentState = State.Chasing;
        }

        if(agent.remainingDistance < 0.5f)
        {
            SetRandomPoint();
        }
    }

    void Chase()
    {
        if(IsInRange(detectionRange) == true) 
        {
            SetRandomPoint();
            currentState = State.Patrolling;
        }

        if(IsInRange(attackRange) == true) 
        {
            currentState = State.Attacking;
        }
        
        agent.destination = player.position; 
    }

    void Attack()
    {
        Debug.Log ("Ataque!");

        currentState = State.Chasing;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        
        foreach(Transform points in patrolPoints)
        {
            Gizmos.DrawWireSphere(points.position, 0.5f);
        }
        
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
