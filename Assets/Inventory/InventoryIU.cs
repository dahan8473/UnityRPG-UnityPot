using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryIU : MonoBehaviour
{
    Inventory inventory;

    public Transform itemsParent;

    InventorySlot[] slots;
    
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    
    void Update()
    {
        
    }
    void UpdateUI()
    {
        Debug.Log("updating UI");
    }
}
