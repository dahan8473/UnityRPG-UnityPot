using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Collectables item;
    public Image icon;
    public Text itemCount;
    /*public void Update()
    {
        if (item != null && itemCount != null)
        {

            // Display the integer value in the text area
            itemCount.text = item.itemAmount.ToString();
        }
    }*/
    public void AddItem(Collectables newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
    }
    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}
