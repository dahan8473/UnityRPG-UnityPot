using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryIU : MonoBehaviour
{
    Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateUI()
    {
        Debug.Log("updating UI");
    }
}
