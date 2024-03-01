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

    }

    void Patrol()
    {

    }

    void Chase()
    {
        
    }

    void Attack()
    {
        
    }
}
