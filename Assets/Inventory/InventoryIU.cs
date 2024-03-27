using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class InventoryIU : MonoBehaviour
{
    Inventory inventory;

    public Transform itemsParent;

    InventorySlot[] slots;

    public GameObject inventoryUI;
    
    
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }
    void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }

    }
}
