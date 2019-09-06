using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{

    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Duplicate Inventory");
            return;
        }
        instance = this;
    }
    #endregion


    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<Item> items = new List<Item>(); // Our current list of items in the inventory
    public int space = 25;  // Amount of item spaces


    private void Start()
    {
        Debug.Log("Inventory.cs Start()");
    }


    // Add a new item if enough room
    public void Add(Item item)
    {
        if (item.showInInventory)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough room.");
                return;
            }

            Debug.Log("Adding Item:");
            Debug.Log(item.GetItemInfo());
            items.Add(item);

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].icon == null)
                    Debug.Log("item.icon at index " + i.ToString() + " is null");
            }
            //if (onItemChangedCallback != null)
            //   onItemChangedCallback.Invoke();
        }
    }


    // Remove an item
    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }


}