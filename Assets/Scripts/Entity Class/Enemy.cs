using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Enemy : Entity
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    //Patrolling
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float attackCD;
    bool isAttacking;

    //States
    public float sightRange, attackRange;
    public bool isPlayerInSightRange, isPlayerInAttackRange;


    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check if Player in sight range
        isPlayerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        //Check if Player in attack range
        isPlayerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!isPlayerInAttackRange && !isPlayerInSightRange)
        {
            Patroling();
        }
        if (!isPlayerInAttackRange && isPlayerInSightRange)
        {
            Chase();
        }
        if (isPlayerInAttackRange && isPlayerInSightRange)
        {
            Attack();
        }
    }

    private void Patroling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1.5f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        float maxRangeX = transform.position.x + walkPointRange;
        float maxRangeZ = transform.position.z + walkPointRange;

        float minRangeX = transform.position.x - walkPointRange;
        float minRangeZ = transform.position.z - walkPointRange;

        
        while (randomX + transform.position.x < minRangeX || randomX + transform.position.x > maxRangeX) 
        {
            randomX = Random.Range(-walkPointRange, walkPointRange);
        }
        while (randomZ + transform.position.z < minRangeZ || randomZ + transform.position.z > maxRangeZ)
        {
            randomX = Random.Range(-walkPointRange, walkPointRange);
        }

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    private void Chase()
    {
        agent.SetDestination(player.position);
    }

    private void Attack()
    {
        //Stop moving
        agent.SetDestination(transform.position);

        //Look at player
        transform.LookAt(player);

        if (!isAttacking)
        {

            //Attack Code
            Debug.Log("Enemy Attacking");

            isAttacking = true;
            Invoke(nameof(ResetAttack), attackCD);
        }
    }

    private void ResetAttack()
    {
        isAttacking = false;
    }

    /*public float AggressionLevel;


    public Vector3[] PatrolPath;

    //public Collectable LoopDrop;


    public override void Move()
    {
        
    }

    public void Patrol()
    {

    }

    /*public Collectable DropsLoot()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    } */
}
