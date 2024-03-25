using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float pickUpRange = 3f;

    public Transform player;
    public bool isPlayerInRange;
    public LayerMask playerLayer;

    public GameObject optionToCollect;



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, pickUpRange);
    }

    void Collect()
    {
        Debug.Log("Collecting item");
        //add to inventory
        Destroy(gameObject);
    }
    private void Update()
    {
        CheckPlayerInRange();

        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            Collect();
        }
    }


    private void CheckPlayerInRange()
    {
        isPlayerInRange = Physics.CheckSphere(transform.position, pickUpRange, playerLayer);

        if (isPlayerInRange)
        {
            Debug.Log("Click 'F' to collect");
        }

    }
}
