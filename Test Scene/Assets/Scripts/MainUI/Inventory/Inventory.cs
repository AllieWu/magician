﻿using System;
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

    public Dictionary<Item, int> itemsDict = new Dictionary<Item, int>();
    public List<Item> keys = new List<Item>(); // Our current list of items in the inventory
    public int space = 25;  // Amount of item spaces

    // Add a new item if enough room
    public void Add(Item item)
    {
        if (item.showInInventory)
        {
            keys = new List<Item>(this.itemsDict.Keys);

            int index = keys.FindIndex(i => i.ItemID == item.ItemID);
            if (index >= 0)
            {
                Debug.Log("We found this item! We currently have " + itemsDict[keys[index]].ToString());
                itemsDict[keys[index]] += 1;
            }
            else
            {
                if (itemsDict.Count >= space)
                {
                    Debug.Log("Not enough room.");
                    return;
                }

                Debug.Log(item.GetItemInfo());
                itemsDict.Add(item, 1);
            }
            //if (onItemChangedCallback != null)
            //   onItemChangedCallback.Invoke();
            keys = new List<Item>(this.itemsDict.Keys);
        }
    }


    // Remove an item
    public void Remove(Item item)
    {
        if (item!=null)
        {
            itemsDict.Remove(item);
            keys = new List<Item>(this.itemsDict.Keys);
        }

        //if (onItemChangedCallback != null)
        //  onItemChangedCallback.Invoke();
    }


}