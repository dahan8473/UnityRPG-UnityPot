using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    public Transform player;
    public string[] dialogue;
    public bool isPlayerInRange;
    public float talkRange;
    public LayerMask whatIsPlayer;
    public GameObject panel;
    public GameObject optionSpeak;
    public Dialogue dialogueBox;
    public bool isReading;


    //public Quest[] QuestGiven;

    public string Kingdom;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        //Check if Player in range
        isPlayerInRange = Physics.CheckSphere(transform.position, talkRange, whatIsPlayer);

        if (isPlayerInRange)
        {
            dialogueBox.lines = dialogue;
        }

        if (isPlayerInRange && !isReading)
        {
            optionSpeak.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                isReading = true;
                optionSpeak.SetActive(false);
                panel.SetActive(true);
            }
        }
        if (!isPlayerInRange)
        {
            isReading = false;
            optionSpeak.SetActive(false);
            panel.SetActive(false);
        }
    }

    //public void TalkToPlayer()
    //{
    //
    //}

    /*public Quest GiveQuest()
    {

    }
    */

}
