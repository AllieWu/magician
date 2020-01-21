using System;
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

    public void UpdateKeys()
    {
        keys = new List<Item>(itemsDict.Keys);
    }


    // Add a new item if enough room
    public void Add(Item item)
    {
        if (item.showInInventory)
        {
            keys = new List<Item>(this.itemsDict.Keys);

            int index = keys.FindIndex(i => i.ItemID == item.ItemID);
            if (index >= 0)
            {
                //Debug.Log("We found this item! We currently have " + itemsDict[keys[index]].ToString());
                itemsDict[keys[index]] += 1;
            }
            else
            {
                if (itemsDict.Count >= space)
                {
                    Debug.Log("Not enough room.");
                    return;
                }

                // Debug.Log(item.GetItemInfo());
                itemsDict.Add(item, 1);
            }
            //if (onItemChangedCallback != null)
            //   onItemChangedCallback.Invoke();
            UpdateKeys();
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

    public Dictionary<(int, int, string, string, bool), int> GetInvData()
    {
        Dictionary<(int, int, string, string, bool), int> returnDict = new Dictionary<(int, int, string, string, bool), int>();
        foreach (KeyValuePair<Item, int> entry in itemsDict)
        {
            returnDict.Add((entry.Key.ItemID, entry.Key.TypeID, entry.Key.Name, entry.Key.Description, entry.Key.showInInventory), entry.Value);
            // do something with entry.Value or entry.Key
        }


        return returnDict;
    }

    public void SetInvData(Dictionary<(int, int, string, string, bool), int> inp)
    {
        itemsDict.Clear();
        foreach (KeyValuePair<(int, int, string, string, bool), int> entry in inp)
        {
            itemsDict.Add(new Item(entry.Key), entry.Value);
        }

    }

}