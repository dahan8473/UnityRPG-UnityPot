using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
        }
        instance = this; 
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;

    public int space = 6;

    public List<Collectables> items = new List<Collectables>();

    public bool Add (Collectables item)
    {
        Collectables copyItem = Instantiate(item);
       
        if (!item.isDefaultItem) 
        {
            if(items.Count >= space)
            {
                Debug.Log("Not enough room.");
                return false;
            }

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].name == item.name)
                {
                    item.itemAmount++;
                    Debug.Log(item.itemAmount);
                    return true;
                }

            }

            items.Add(item); 
            item.itemAmount = 1;
            Debug.Log(item.itemAmount);
            if (onItemChangedCallBack != null)
                onItemChangedCallBack.Invoke();

        }
        return true;
    }
    public void Remove (Collectables item)
    {
        items.Remove(item);

        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }
}
