using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //
    public float AggressionLevel;
    public float Health;
    //public Collectable LoopDrop;

    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //patrolling
    public Vector3 PatrolPath;
    bool PatrolPathSet;
    public float PatrolPathRange;

    //attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("PlayerObj").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }
    private void Patrolling()
    {
        if (!PatrolPathSet) SearchPatrolPoint();

        if (PatrolPathSet) agent.SetDestination(PatrolPath);

        Vector3 distanceToPatrolPath = transform.position - PatrolPath;

        if (distanceToPatrolPath.magnitude < 1f) PatrolPathSet = false;
    }

    private void SearchPatrolPoint()
    {
        float randomZ = Random.Range(-PatrolPathRange, PatrolPathRange);
        float randomX = Random.Range(-PatrolPathRange, PatrolPathRange);

        PatrolPath = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(PatrolPath, - transform.up, 2f, whatIsGround))
        {
            PatrolPathSet = true;
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if(!alreadyAttacked)
        {
            //attack code goes here


            //
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    //code getting attacked.
    public void TakeDamage(float amount)
    {
        Health -= amount;
        if (Health <= 0)
        {
            Object.Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

}
