using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    //public Quest[] QuestGiven;

    public string Kingdom;


    /*public Quest GiveQuest()
    {

    }
    */

    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsPlayer;

    //patrolling
    public Vector3 PatrolPath;
    public float PatrolPathRange;


    //States
    public float sightRange;
    public bool playerInSightRange;

    private void Awake()
    {
        player = GameObject.Find("PlayerObj").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (playerInSightRange) InitiateDialogue();

    }
    private void InitiateDialogue()
    {

    }




}
